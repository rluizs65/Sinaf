using System.ComponentModel;

namespace Base.Core.Enumerators

{
    public enum ErrorCode
    {
        [Description("Nenhum registro encontrado")]
        ERROR_RECORD_NOT_FOUND = 310,

        [Description("Status de operação inválido")]
        ERROR_INVALID_STATUS_OPERATION = 311,

        [Description("Nome do serviço é obrigatório")]
        ERROR_REQUIRED_SERVICE_NAME = 312,

        [Description("Erro de exceção")]
        EXCEPTION_ERROR = 313,

        [Description("Login inválido")]
        ERROR_INVALID_LOGIN = 314,

        [Description("Parâmetro inválido")]
        ERROR_INVALID_PARAMETER = 315,

        [Description("CPF inválido")]
        ERROR_INVALID_CPF = 316,

        [Description("Documento não informado")]
        ERROR_DOCUMENT_NOT_FOUND = 317,

        [Description("Erro ao processar solicitação")]
        ERROR_REQUEST_PROCESS = 318,

        [Description("Preenchimento obrigatório")]
        ERROR_REQUIRED_FILL = 319
    }
}
