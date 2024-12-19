namespace Sisir.Entity

{

    public interface IEntity
    {
        ValidationResponse Validate();
        void Insert();

        bool Update();

        void Delete();
    }


    public class ValidationResponse
    {
        public bool isValid { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public bool AbortOperation { get; set; }
    }





}
