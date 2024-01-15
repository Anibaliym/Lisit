using App.Domain.Core.Data;
using FluentValidation.Results;

namespace App.Domain.Core.Messaging
{
    public abstract class CommandHandler
    {
        protected CommandResponse CommandResponse;

        protected CommandHandler()
        {
            CommandResponse = new CommandResponse();

        }

        protected void AddError(string mensagem)
        {
            CommandResponse.ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<CommandResponse> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.Commit()) AddError(message);

            return CommandResponse;
        }

        protected async Task<CommandResponse> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "Ocurrio un error al intentar guardar la información.").ConfigureAwait(false);
        }
    }
}
