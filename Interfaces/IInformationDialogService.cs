namespace ServicesLib.Interfaces
{
    public interface IInformationDialogService
    {
        void ShowError(string Message);

        void ShowInformation(string Message, string Tittle);
    }
}
