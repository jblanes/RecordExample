Este es un proyecto de ejemplo!
Varias partes importantes de un proyecto de producción han sido eliminadas para poder presentar más claramente las ideas principales.

Validaciones sencillas de campos requeridos o no, rangos, etc. no se cubren en este ejemplo.
El ejemplo es solo para campos que necesitan validaciones especiales. 

En este ejemplo se validan dos campos, Fecha de nacimiento y Salario:
El primero no debe permitir edades mayores a 125 ni fechas futuras.
El segundo, aunque es un ejemplo de validación de rango, también sirve para documentar cómo proteger un campo con un valor dentro de rango específico, en el caso de salario, de 0 a $1 millón.

Para comenzar el análisis, favor comenzar viendo los comentarios en la pantalla principal /Pages/Index
en el proyecto BC.RecordUseExample.UI.Razor
