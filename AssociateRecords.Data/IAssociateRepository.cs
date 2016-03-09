using AssociateRecords.Domain;

namespace AssociateRecords.Data
{
    public interface IAssociateRepository
    {
        void AddNewAssociateRecord(Associate associate);

        Associate UpdateAssociateRecord(Associate associate);
    }
}
