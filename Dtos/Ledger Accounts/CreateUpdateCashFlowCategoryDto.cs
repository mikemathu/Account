namespace Accounts.Dtos
{
    public class CreateUpdateCashFlowCategoryDto
    {
        public int CashFlowCategoryID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int IsActive { get; set; }
    }
}
