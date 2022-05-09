Console.Title = "The Locked Door";

//gets initialPasscode from user for door
int initialPasscode = GetInt("What is the inital passcode? ");
Door door = new Door(initialPasscode);

//method to get int combined with area for string to reuse code
int GetInt(string text)
{
    Console.WriteLine(text + " ");
    return Convert.ToInt32(Console.ReadLine());
}

//while loop that contiunes to run through states of the door, 
while(true)
{
    Console.WriteLine($"The door is {door.State}. Please type what do you want to do? open, close, unlock, change code  ");
    string ? command = Console.ReadLine();

    switch (command)
    {
        case "open":
            door.Open();
            break;
        case "close":
            door.Close();
            break;
        case "lock":
            door.Lock();
            break;
        case "unlock":
            int guess = GetInt("What is the current passcode? ");
            door.Unlock(guess);
            break;
        case "change code":
            int currentCode = GetInt("What is the current passcode?");
            int newCode = GetInt("What do you want to change it to?");
            door.ChangeCode(currentCode, newCode);
            break;
        
    }
}

//class for door
public class Door
{
    //private variable
    private int _passcode;
    //getter and setter
    public DoorIs State { get; private set; }
    
    public Door(int initialPasscode)
    {
        _passcode = initialPasscode;
        State = DoorIs.Closed;
    }

    //methods for the states of the door
    public void Close()
    {
        if (State == DoorIs.Open) State = DoorIs.Closed;
    }

    public void Open()
    {
        if (State == DoorIs.Closed) State = DoorIs.Open;
    }

    public void Lock()
    {
        if (State == DoorIs.Closed) State = DoorIs.Locked;
    }

    public void Unlock(int passcode)
    {
        if (State == DoorIs.Locked && passcode == _passcode) State = DoorIs.Closed;
    }

    public void ChangeCode(int oldPasscode, int newPasscode)
    {
        if (oldPasscode == _passcode) _passcode = newPasscode;
    }

}

//enums we use with switch expression and for variables of door
public enum DoorIs { Open, Closed, Locked }