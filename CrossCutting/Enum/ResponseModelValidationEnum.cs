using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossCutting.Enum
{
    public class ResponseModelValidationEnum : EnumHelper
    {
        public string Message { get; private set; }
        public ResponseModelValidationEnum(int id, string name, string message) : base(id, name)
        {
            Message = message;
        }

        public static ResponseModelValidationEnum NotEmpty = new ResponseModelValidationEnum(
                id: 1,
                name: nameof(NotEmpty),
                message: "Este campo es obligatorio. No puede dejar este campo en blanco."
            );
        public static ResponseModelValidationEnum NotNull = new ResponseModelValidationEnum(
                id: 2,
                name: nameof(NotNull),
                message: "Este campo es obligatorio."
            );
        public static ResponseModelValidationEnum Length = new ResponseModelValidationEnum(
                id: 3,
                name: nameof(Length),
                message: "Este campo debe estar entre :min y :max caracteres."
            );
        public static ResponseModelValidationEnum MaximumLength = new ResponseModelValidationEnum(
                id: 4,
                name: nameof(MaximumLength),
                message: "Este campo no puede ser mayor a :max caracteres."
            );
        public static ResponseModelValidationEnum EmailAddress = new ResponseModelValidationEnum(
                id: 5,
                name: nameof(EmailAddress),
                message: "Introduzca una dirección de correo electrónico válida."
            );
        public static ResponseModelValidationEnum LessThan = new ResponseModelValidationEnum(
                id: 6,
                name: nameof(LessThan),
                message: "Este campo debe ser menor a :min."
            );
        public static ResponseModelValidationEnum LessThanOrEqualTo = new ResponseModelValidationEnum(
                id: 7,
                name: nameof(LessThanOrEqualTo),
                message: "Este campo debe ser menor o igual a :min."
            );
        public static ResponseModelValidationEnum GreaterThan = new ResponseModelValidationEnum(
                id: 8,
                name: nameof(GreaterThan),
                message: "Este campo debe ser mayor a :max."
            );
        public static ResponseModelValidationEnum GreaterThanOrEqualTo = new ResponseModelValidationEnum(
                id: 9,
                name: nameof(GreaterThanOrEqualTo),
                message: "Este campo debe ser mayor o igual a :max."
            );
        public static ResponseModelValidationEnum Must = new ResponseModelValidationEnum(
                id: 10,
                name: nameof(Must),
                message: "Introduzca un parametro válido."
            );
        public static ResponseModelValidationEnum Matches = new ResponseModelValidationEnum(
                id: 11,
                name: nameof(Matches),
                message: "Introduzca un parametro válido."
            );

        public static IList<ResponseModelValidationEnum> List() => new[] {
            NotEmpty,
            NotNull,
            Length,
            MaximumLength,
            EmailAddress,
            LessThan,
            LessThanOrEqualTo,
            GreaterThan,
            GreaterThanOrEqualTo,
            Must,
            Matches
        };

        public static ResponseModelValidationEnum FilterByName(string value)
        {
            var result = List().Single(x => String.Equals(x.Name, value, StringComparison.OrdinalIgnoreCase));

            return result;
        }

        public static ResponseModelValidationEnum FilterById(int value)
        {
            var result = List().Single(x => x.Id == value);

            return result;
        }
    }
}
