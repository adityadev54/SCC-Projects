/**
 * CartManager manages the cart for the Cafe POS System, including product loading, cart operations, and bill generation.
 */

package models;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.DeserializationFeature;
import java.io.InputStream;
import java.text.DecimalFormat;
import java.util.*;

public class CartManager {
    private final List<CartItem> cartItems;
    private final Map<String, Product> productDatabase;
    private static final DecimalFormat df = new DecimalFormat("#.00");

    // Initializes an empty cart and loads the products into the product database.
    public CartManager() {
        cartItems = new ArrayList<>();
        productDatabase = new HashMap<>();
        loadProducts();
    }

    // Loads products from the JSON file into the product database.
    // This also throws a run time exception if loading fails.
    private void loadProducts() {
        try {
            // Configure ObjectMapper to ignore unknown properties in the JSON.
            ObjectMapper mapper = new ObjectMapper();
            mapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
            InputStream inputStream = getClass().getResourceAsStream("/products.json");
            if (inputStream == null) {
                throw new IllegalStateException("products.json not found");
            }
            Product[] products = mapper.readValue(inputStream, Product[].class);
            for (Product product : products) {
                productDatabase.put(product.getName(), product);
            }
        } catch (Exception e) {
            throw new RuntimeException("Failed to load products: " + e.getMessage(), e);
        }
    }

    // Returns a copy of the product database.
    // @return A new HashMap containing all products.
    public Map<String, Product> getProductDatabase() {
        return new HashMap<>(productDatabase);
    }

    // Add an item to the cart with the specified name and quantity.
    public void addItem(String name, int quantity) throws IllegalArgumentException {
        if (!productDatabase.containsKey(name)) {
            throw new IllegalArgumentException("Item not found in product database: " + name);
        }
        if (quantity <= 0) {
            throw new IllegalArgumentException("Quantity must be greater than 0");
        }
        Product product = productDatabase.get(name);
        cartItems.add(new CartItem(name, quantity, product.getPrice(), product.getImage()));
    }

    // Remove an item from the cart at the specified index.
    public void removeItem(int index) {
        if (index < 0 || index >= cartItems.size()) {
            throw new IllegalArgumentException("Invalid item index: " + index);
        }
        cartItems.remove(index);
    }

    // Clear all items from the cart.
    public void clearCart() {
        cartItems.clear();
    }

    // Calculates the total cost of all items in the cart.
    public double getTotal() {
        return cartItems.stream().mapToDouble(CartItem::getTotal).sum();
    }

    // This generates a bill for the current cart, applying the specified discount and processing the payment.
    // Also clears the cart after generating a bill.
    public String generateBill(double payment, double discountPercentage) {
        if (cartItems.isEmpty()) {
            throw new IllegalArgumentException("Cart is empty");
        }
        if (discountPercentage < 0 || discountPercentage > 100) {
            throw new IllegalArgumentException("Discount percentage must be between 0 and 100");
        }

        // Calculates the subtotal, discoun, and final total.
        double subtotal = getTotal();
        double discountAmount = subtotal * (discountPercentage / 100);
        double finalTotal = subtotal - discountAmount;

        if (payment < finalTotal) {
            throw new IllegalArgumentException("Payment must be at least $" + df.format(finalTotal));
        }

        // Builds the bill string with formatted details
        StringBuilder bill = new StringBuilder();
        bill.append("               ===== Cafe POS Bill =====\n");
        bill.append(String.format("%-20s %-10s %-10s %-10s\n", "Item", "Qty", "Price", "Total"));
        bill.append("------------------------------------------------\n");
        for (CartItem item : cartItems) {
            bill.append(String.format("%-20s %-10d $%-9.2f $%-9.2f\n",
                    item.getName(), item.getQuantity(), item.getPrice(), item.getTotal()));
        }
        bill.append("------------------------------------------------\n");
        bill.append(String.format("%-20s $%-9.2f\n", "Subtotal:", subtotal));
        if (discountPercentage > 0) {
            bill.append(String.format("%-20s %-9.2f%%\n", "Discount:", discountPercentage));
            bill.append(String.format("%-20s $%-9.2f\n", "Discount Amount:", discountAmount));
        }
        bill.append(String.format("%-20s $%-9.2f\n", "Final Total:", finalTotal));
        bill.append(String.format("%-20s $%-9.2f\n", "Payment:", payment));
        bill.append(String.format("%-20s $%-9.2f\n", "Change:", payment - finalTotal));
        bill.append("================================================");

        // Clear the cart
        clearCart();
        return bill.toString();
    }

    // Returns a copy of the current cart items.
    public List<CartItem> getCartItems() {
        return new ArrayList<>(cartItems);
    }
}