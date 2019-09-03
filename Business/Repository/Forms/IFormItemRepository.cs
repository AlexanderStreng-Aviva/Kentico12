namespace Business.Repository.Forms
{
    public interface IFormItemRepository : IRepository
    {
        void InsertFormItem(string className, IFormViewModel viewModel);
    }
}