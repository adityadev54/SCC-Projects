import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.util.Objects;

public class PointOfSale extends Application {
    @Override
    public void start(Stage stage) throws Exception {
        System.out.println("Loading loginview.fxml: " + getClass().getResource("/loginview.fxml"));
        System.out.println("Loading styles.css: " + getClass().getResource("/styles.css"));
        FXMLLoader fxmlLoader = new FXMLLoader(getClass().getResource("/loginview.fxml"));
        Scene scene = new Scene(fxmlLoader.load(), 300, 400);
        scene.getStylesheets().add(Objects.requireNonNull(getClass().getResource("/styles.css")).toExternalForm());
        stage.setTitle("Cafe POS Login");
        stage.setScene(scene);
        stage.show();
    }

    public static void main(String[] args) {
        launch(args);
    }
}