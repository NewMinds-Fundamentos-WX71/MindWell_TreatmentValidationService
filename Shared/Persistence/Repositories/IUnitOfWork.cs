namespace MindWell_TreatmentValidation.Shared.Persistence.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}