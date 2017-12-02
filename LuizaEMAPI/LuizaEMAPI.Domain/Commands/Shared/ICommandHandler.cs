namespace LuizaEMAPI.Domain.Commands.Shared
{
    public interface ICommandHandler<T> where T: ICommand
    {
        ICommandResult Handler(T command);
    }
}
