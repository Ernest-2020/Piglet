public class PlayerController:IExecute
{
    private readonly PlayerBase _player;
    private readonly Joystick _joystick;

    public PlayerController(PlayerBase player, Joystick joystick)
    {
        _player = player;
        _joystick = joystick;
    }

    public void Execute()
    {
        _player.Move(_joystick.Horizontal, _joystick.Vertical);
        _player.RotatePig();
    }

    
}
