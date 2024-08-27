Este es un proyecto de ejemplo!<br/>
Varios módulos importantes existentes en un proyecto de producción (testing, logging, monitoring, APIs, etc) han sido eliminados para poder presentar más claramente las ideas principales.<br/>

Validaciones sencillas de campos requeridos o no, rangos, etc. no se cubren en este ejemplo.<br/>
El ejemplo es solo para campos que necesitan validaciones especiales. <br/>

En este ejemplo se validan dos campos, Fecha de nacimiento y Salario:<br/>
El primero no debe permitir edades mayores a 125 ni fechas futuras.<br/>
El segundo, aunque es un ejemplo de validación de rango, también sirve para documentar cómo proteger un campo con un valor dentro de un rango específico. En este caso del salario, de 0 a $1 millón.<br/>

Las validaciones se hacen con clases sencillas a modo de ejemplo. Para producción es mejor usar librerías como FluentValidation, especialmente si se usa con librearías para manejo de mensajes como MediatR.

Para comenzar el análisis, favor comenzar viendo los comentarios en la pantalla principal /Pages/Index
en el proyecto BC.RecordUseExample.UI.Razor
