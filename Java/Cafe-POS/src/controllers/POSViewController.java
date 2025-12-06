/**
 * POS View Controller is the controller for the main POS View, whereby it handles product selection, cart management, and bill generation.
 */

package controllers;

import javafx.beans.property.SimpleStringProperty;
import javafx.collections.FXCollections;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.FlowPane;
import javafx.scene.layout.VBox;
import javafx.stage.Stage;
import models.CartItem;
import models.Product;
import models.CartManager;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

public class POSViewController {
    // FXML-injected UI components
    @FXML private Label usernameLabel;
    @FXML private ComboBox<String> categoryComboBox;
    @FXML private ComboBox<String> productComboBox;
    @FXML private TextField quantityField;
    @FXML private FlowPane productGrid;
    @FXML private ImageView previewImage;
    @FXML private TableView<CartItem> cartTable;
    @FXML private TableColumn<CartItem, ImageView> imageColumn;
    @FXML private TableColumn<CartItem, String> nameColumn;
    @FXML private TableColumn<CartItem, Integer> quantityColumn;
    @FXML private TableColumn<CartItem, String> priceColumn;
    @FXML private TableColumn<CartItem, String> totalColumn;
    @FXML private Label subtotalLabel;
    @FXML private TextField discountField;
    @FXML private Label discountedTotalLabel;
    @FXML private TextField paymentField;

    // Manages the cart and product database.
    private CartManager cartManager;

    // Stores the history of the generated bills.
    private List<String> orderHistory;

    // Stores the currently logged-in user's username.
    private String loggedInUser;

    // DecimalFormat for formatting monetry values to 2 decimal places.
    private static final DecimalFormat df = new DecimalFormat("#.00");

    // Updates the username Label
    private void updateUsernameLabel() {
        if (usernameLabel != null) {
            if (loggedInUser != null && !loggedInUser.isEmpty()) {
                usernameLabel.setText("Logged in as: " + loggedInUser);
            } else {
                usernameLabel.setText("Logged in as: Adi");
            }
        } else {
            System.err.println("usernameLabel is null, cannot update username display");
        }
    }

    // Handles Username CLicks
    @FXML
    private void handleUsernameClick() {
        String userInfo = "Username: " + (loggedInUser != null && !loggedInUser.isEmpty() ? loggedInUser : "Guest");
        TextArea infoArea = new TextArea(userInfo);
        infoArea.setEditable(false);
        infoArea.setStyle("-fx-font-family: 'Monospaced'; -fx-font-size: 14;");
        DialogPane dialogPane = new DialogPane();
        dialogPane.setContent(infoArea);
        dialogPane.setMinSize(200, 100);
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("User Profile");
        alert.setHeaderText(null);
        alert.setDialogPane(dialogPane);
        alert.getButtonTypes().setAll(ButtonType.CLOSE);  // Add Close button
        alert.showAndWait();
    }

    // Initializes the POS view by setting up the cart, categories, and table columns.
    // Also sets up listeners for dynamic updates.
    public void initialize() {
        cartManager = new CartManager();
        orderHistory = new ArrayList<>();

        updateUsernameLabel();

        // Populates category dropdown with distinct, sorted categories.
        List<String> categories = cartManager.getProductDatabase().values().stream()
                .map(Product::getCategory)
                .distinct()
                .sorted()
                .collect(Collectors.toList());
        categoryComboBox.setItems(FXCollections.observableArrayList(categories));
        categoryComboBox.getSelectionModel().selectFirst();
        updateProductGrid();

        // Configures table columns for cart display.
        imageColumn.setCellValueFactory(cellData -> {
            String imagePath = cellData.getValue().getImage();
            ImageView imageView = new ImageView();
            try {
                Image image = new Image(Objects.requireNonNull(getClass().getResourceAsStream(imagePath)));
                imageView.setImage(image);
                imageView.setFitWidth(50);
                imageView.setFitHeight(50);
                imageView.setPreserveRatio(true);
            } catch (Exception e) {
                System.err.println("Failed to load image: " + imagePath);
            }
            return javafx.beans.binding.Bindings.createObjectBinding(() -> imageView);
        });
        nameColumn.setCellValueFactory(new PropertyValueFactory<>("name"));
        quantityColumn.setCellValueFactory(new PropertyValueFactory<>("quantity"));
        priceColumn.setCellValueFactory(cellData -> new SimpleStringProperty("$" + df.format(cellData.getValue().getPrice())));
        totalColumn.setCellValueFactory(cellData -> new SimpleStringProperty("$" + df.format(cellData.getValue().getTotal())));

        cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
        updateSubtotal();

        // Updates the subtotal whenever the discount is applied
        discountField.textProperty().addListener((obs, oldValue, newValue) -> updateSubtotal());
    }

    // Updates the product grid and product dropdown based on the selected category.
    @FXML
    private void updateProductGrid() {
        productGrid.getChildren().clear();
        String selectedCategory = categoryComboBox.getSelectionModel().getSelectedItem();
        if (selectedCategory == null) return;

        // Filter and sort products by the selected category.
        List<Product> products = cartManager.getProductDatabase().values().stream()
                .filter(p -> p.getCategory().equals(selectedCategory))
                .sorted(Comparator.comparing(Product::getName))
                .collect(Collectors.toList());

        // Updates product dropdown
        productComboBox.setItems(FXCollections.observableArrayList(products.stream()
                .map(Product::getName)
                .collect(Collectors.toList())));
        productComboBox.getSelectionModel().selectFirst();

        // Creates a product card for each product in the grid
        for (Product product : products) {
            VBox productBox = new VBox(5);
            productBox.getStyleClass().add("product-box");
            ImageView imageView = new ImageView();
            try {
                Image image = new Image(Objects.requireNonNull(getClass().getResourceAsStream(product.getImage())));
                imageView.setImage(image);
                imageView.setFitWidth(80);
                imageView.setFitHeight(80);
                imageView.setPreserveRatio(true);
            } catch (Exception e) {
                System.err.println("Failed to load image: " + product.getImage());
            }
            Label nameLabel = new Label(product.getName());
            nameLabel.getStyleClass().add("product-label");
            productBox.getChildren().addAll(imageView, nameLabel);
            productBox.setOnMouseClicked(e -> {
                productComboBox.getSelectionModel().select(product.getName());
                updateImagePreview();
            });
            productGrid.getChildren().add(productBox);
        }
        updateImagePreview();
    }


    // Updates the image preview based on the selected product in the product dropdown
    @FXML
    private void updateImagePreview() {
        String selectedProduct = productComboBox.getSelectionModel().getSelectedItem();
        if (selectedProduct != null) {
            Product product = cartManager.getProductDatabase().get(selectedProduct);
            try {
                Image image = new Image(Objects.requireNonNull(getClass().getResourceAsStream(product.getImage())));
                previewImage.setImage(image);
            } catch (Exception e) {
                System.err.println("Failed to load preview image: " + product.getImage());
                previewImage.setImage(null);
            }
        } else {
            previewImage.setImage(null);
        }
    }


    // Adds the selected product and quantity to the cart,
    // Also updates the cart table and subtotal
    @FXML
    private void handleAddItem() {
        try {
            String name = productComboBox.getSelectionModel().getSelectedItem();
            int quantity = Integer.parseInt(quantityField.getText().trim());

            cartManager.addItem(name, quantity);
            cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
            updateSubtotal();

            quantityField.clear();
        } catch (NumberFormatException e) {
            showAlert("Invalid Input", "Please enter a valid quantity.");
        } catch (IllegalArgumentException e) {
            showAlert("Error", e.getMessage());
        }
    }

    // Quickly adds one Espresso to the cart
    // Updates the cart table and subtotal
    @FXML
    private void handleQuickEspresso() {
        try {
            cartManager.addItem("Espresso", 1);
            cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
            updateSubtotal();
        } catch (IllegalArgumentException e) {
            showAlert("Error", e.getMessage());
        }
    }

    // Removes the selected item from the cart.
    // Updates the cart table and subtotal.
    @FXML
    private void handleRemoveItem() {
        int selectedIndex = cartTable.getSelectionModel().getSelectedIndex();
        if (selectedIndex >= 0) {
            cartManager.removeItem(selectedIndex);
            cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
            updateSubtotal();
        } else {
            showAlert("No Selection", "Please select an item to remove.");
        }
    }

    // Clears all items from the cart.
    // Updates the cart table and subtotal.
    @FXML
    private void handleClearCart() {
        cartManager.clearCart();
        cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
        updateSubtotal();
    }

    // Displays the order history in a dialog
    // Shows a message if no orders exists.
    @FXML
    private void handleOrderHistory() {
        if (orderHistory.isEmpty()) {
            showAlert("Order History", "No orders have been placed yet.");
            return;
        }

        TextArea historyArea = new TextArea(String.join("\n\n", orderHistory));
        historyArea.setEditable(false);
        historyArea.setStyle("-fx-font-family: 'Monospaced'; -fx-font-size: 14;");
        DialogPane dialogPane = new DialogPane();
        dialogPane.setContent(historyArea);
        dialogPane.setMinSize(400, 300);
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Order History");
        alert.setHeaderText(null);
        alert.setDialogPane(dialogPane);
        alert.getButtonTypes().setAll(ButtonType.CLOSE);  // Add Close button
        alert.showAndWait();
    }


    // Generates the bill for the current cart, applying the discount and processing the payment.
    // Also displays the bill in a dialog and adds it to the order history.
    @FXML
    private void handleGenerateBill() {
        try {
            double payment = Double.parseDouble(paymentField.getText().trim());
            double discountPercentage = getDiscountPercentage();
            String bill = cartManager.generateBill(payment, discountPercentage);

            orderHistory.add(bill);

            // Display the bill in a dialog
            TextArea billArea = new TextArea(bill);
            billArea.setEditable(false);
            billArea.setStyle("-fx-font-family: 'Monospaced'; -fx-font-size: 14;");
            DialogPane dialogPane = new DialogPane();
            dialogPane.setContent(billArea);
            dialogPane.setMinSize(400, 300);
            Alert alert = new Alert(Alert.AlertType.INFORMATION);
            alert.setTitle("Bill");
            alert.setHeaderText(null);
            alert.setDialogPane(dialogPane);
            alert.getButtonTypes().setAll(ButtonType.CLOSE);  // Add Close button
            alert.showAndWait();

            cartTable.setItems(FXCollections.observableArrayList(cartManager.getCartItems()));
            updateSubtotal();
            paymentField.clear();
            discountField.clear();
        } catch (NumberFormatException e) {
            showAlert("Invalid Input", "Please enter a valid payment amount or discount percentage.");
        } catch (IllegalArgumentException e) {
            showAlert("Error", e.getMessage());
        }
    }

    // Logs out the user and returns to the login view
    @FXML
    private void handleLogout() {
        try {
            Stage stage = (Stage) cartTable.getScene().getWindow();
            FXMLLoader fxmlLoader = new FXMLLoader(getClass().getResource("/loginview.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 300, 400);
            scene.getStylesheets().add(Objects.requireNonNull(getClass().getResource("/styles.css")).toExternalForm());
            stage.setTitle("Cafe POS Login");
            stage.setScene(scene);
        } catch (Exception e) {
            showAlert("Error", "Failed to load login view: " + e.getMessage());
        }
    }

    // Updates the subtoal and discounted labels based on the cart and discount.
    // Fixed: Changed cartManager.getTotal() to cartManager.getSubtotal() to match CartManager method.
    private void updateSubtotal() {
        double subtotal = cartManager.getTotal();
        subtotalLabel.setText("Subtotal: $" + df.format(subtotal));

        double discountPercentage = getDiscountPercentage();
        double discountAmount = subtotal * (discountPercentage / 100);
        double discountedTotal = subtotal - discountAmount;
        discountedTotalLabel.setText("Total After Discount: $" + df.format(discountedTotal));
    }

    // Retrieves the discount % from the discount field and
    // Returns 0 if the input is invalid or empty.
    private double getDiscountPercentage() {
        try {
            String discountText = discountField.getText().trim();
            return discountText.isEmpty() ? 0.0 : Double.parseDouble(discountText);
        } catch (NumberFormatException e) {
            return 0.0;
        }
    }

    // Displays an error alert with the specified title and message.
    private void showAlert(String title, String message) {
        Alert alert = new Alert(Alert.AlertType.ERROR);
        alert.setTitle(title);
        alert.setHeaderText(null);
        alert.setContentText(message);
        alert.showAndWait();
    }
}