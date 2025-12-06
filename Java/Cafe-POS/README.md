Welcome to Cafe POS System.

Simple steps to follow:

  1. I recommend using Intellij Studio for ths Project.
  2. Important :-
     - If an issue occurs saying "Java Components missing"
     - Just try adding this by going to dropdown where the main file will run:
          
     - Select "Edit Configurations" -> Build and Run File -> Click Modify options and add "Add dependencies with "provided" scope to classpath" ->
       Then lastly add Add VM options and simply add this:
    
       ``` 
         --module-path
         [Add your JavaFX folder lib] or downloaded it from the Project and provide the path here.
         --add-modules
         javafx.controls,javafx.fxml
         --enable-native-access=javafx.graphics
       ```
