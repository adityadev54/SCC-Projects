package pixelquest;
import com.badlogic.gdx.Game;
import pixelquest.screens.MainMenuScreen;

public class GameMain extends Game{
    @Override
    public void create() {
        setScreen(new MainMenuScreen(this));
    }

    @Override
    public void dispose() {
        super.dispose();
    }
}
