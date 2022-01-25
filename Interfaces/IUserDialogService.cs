namespace ServicesLib.Interfaces
{
    public interface IUserDialogService
    {
        bool StartDialogScenario(object o);

        bool Confirm(string Message, string Tittle, bool Choice = false);
    }
}
