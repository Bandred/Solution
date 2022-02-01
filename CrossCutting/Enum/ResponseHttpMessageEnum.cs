using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Enum
{
    public class ResponseHttpMessageEnum : EnumHelper
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }

        public ResponseHttpMessageEnum(int id, string name, bool success, int statusCode, string message) : base(id, name)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public static ResponseHttpMessageEnum Ok = new ResponseHttpMessageEnum(
                id: 1,
                name: nameof(Ok),
                success: true,
                statusCode: 200,
                message: "Solicitud exitosa."
            );
        public static ResponseHttpMessageEnum BadRequest = new ResponseHttpMessageEnum(
                id: 2,
                name: nameof(BadRequest),
                success: false,
                statusCode: 400,
                message: "Solicitud incorrecta."
            );
        public static ResponseHttpMessageEnum InvalidModel = new ResponseHttpMessageEnum(
                id: 3,
                name: nameof(InvalidModel),
                success: false,
                statusCode: 400,
                message: "Modelo invalido."
            );
        public static ResponseHttpMessageEnum Unauthorized = new ResponseHttpMessageEnum(
                id: 4,
                name: nameof(Unauthorized),
                success: false,
                statusCode: 401,
                message: "Usuario no autorizado."
            );
        public static ResponseHttpMessageEnum NotFound = new ResponseHttpMessageEnum(
                id: 5,
                name: nameof(NotFound),
                success: false,
                statusCode: 404,
                message: "La información solicitada no se encuentra."
            );
        public static ResponseHttpMessageEnum Error = new ResponseHttpMessageEnum(
                id: 6,
                name: nameof(Error),
                success: false,
                statusCode: 500,
                message: "Ha ocurrido un error interno y no pudimos completar tu solicitud."
            );
        public static ResponseHttpMessageEnum UserAlreadyExists = new ResponseHttpMessageEnum(
                id: 7,
                name: nameof(UserAlreadyExists),
                success: false,
                statusCode: 400,
                message: "El usuario ya existe."
            );
        public static ResponseHttpMessageEnum UserDoesNotExist = new ResponseHttpMessageEnum(
                id: 8,
                name: nameof(UserDoesNotExist),
                success: false,
                statusCode: 400,
                message: "El usuario no existe."
            );
        public static ResponseHttpMessageEnum GeneralFailure = new ResponseHttpMessageEnum(
                id: 9,
                name: nameof(GeneralFailure),
                success: false,
                statusCode: 500,
                message: "Error al realizar la acción. Verifique los datos y vuelva a intentarlo."
            );

        public static IList<ResponseHttpMessageEnum> List() => new[]
        {
            Ok,
            BadRequest,
            InvalidModel,
            Unauthorized,
            NotFound,
            Error,
            UserAlreadyExists,
            UserDoesNotExist,
            GeneralFailure
        };

        public static ResponseHttpMessageEnum FilterByName(string value)
        {
            var result = List().Single(x => String.Equals(x.Name, value, StringComparison.OrdinalIgnoreCase));

            return result;
        }

        public static ResponseHttpMessageEnum FilterById(int value)
        {
            var result = List().Single(x => x.Id == value);

            return result;
        }
    }
}
