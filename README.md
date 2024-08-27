Este es un proyecto de ejemplo!<br/>
Varios módulos importantes existentes en un proyecto de producción (testing, logging, monitoring, APIs, etc) han sido eliminados para poder presentar más claramente las ideas principales.<br/>

Validaciones sencillas de campos como existencia de valor, etc. no se cubren en este ejemplo.<br/>
El ejemplo es solo para campos que necesitan validaciones especiales. <br/>

En este ejemplo se validan dos campos, Fecha de nacimiento y Salario:<br/>
El primero no debe permitir edades mayores a 125 ni fechas futuras.<br/>
El segundo, aunque es un ejemplo de validación de rango, también sirve para documentar cómo proteger un campo con un valor generado dentro de un rango específico. En este caso del salario, de 0 a $1 millón.<br/>

Las validaciones se hacen con clases sencillas a modo de ejemplo. Para producción es mejor usar librerías como FluentValidation, especialmente si se usa con librerías para manejo de mensajes como MediatR.

Por decisión de diseño, el comando no lanza excepciones cuando se genera con errores, sino que marca los campos incorrectos. Por un lado, esto agiliza el proceso de presentación de mensajes de error al usuario, pero por otro lado, debe prestarse especial atención a que un comando incorrecto nunca entre al sistema para su ejecución. El comando siempre debe ser validado antes de entrar al sistema.

Para comenzar el análisis, favor comenzar viendo los comentarios en la pantalla principal /Pages/Index
en el proyecto BC.RecordUseExample.UI.Razor
