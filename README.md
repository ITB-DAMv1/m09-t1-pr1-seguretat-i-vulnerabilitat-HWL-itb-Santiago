[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)

1 )  L’organització OWASP Foundation va actualitzar en 2021 el seu Top 10 de vulnerabilitats més trobades en aplicacions web. 
  Escull 3 vulnerabilitats d’aquesta llista i descriu-les. Escriu l’impacte que tenen a la seguretat i quins danys pot arribar a fer un atac en aquesta vulnerabilitat. Enumera diferents mesures i tècniques per poder evitar-les.
  
Pérdida de Control de Acceso:
Los usuarios pueden actuar fuera de los permisos otorgados, es decir, pueden divulgar, modificar y eliminar información o ejecutar funciones no autorizadas para el usuario. Ej, un usuario general actúa como superusuario(admin)

El usuario puede acceder a información de una cuenta ajena a la suya con tan solo modificar el URL de la página

El usuario no autenticado puede acceder a cualquier página mediante navegación forzada

Se evita:
  Denegar por defecto los recursos, a excepción de los públicos
  No permitir que el usuario pueda crear, modificar y eliminar cualquier dato
  Generar tokens JWT de corta duración
  Invalidar los identificadores de sesiones al cerrar la sesión

Inyección
  Si tienes una aplicación que usa consultas dinámicas o no parametrizadas a la base de datos y, además ofreces un input al usuario, puede que estés en peligro de un SQL Injection. Esto no es más que el usuario intenta introducir código SQL ejecutable mediante el input que se le suministra para intentar acceder a tu base de datos y así poder:
Eludir autenticación
Robar la identidad del usuario
Convertirse en administrador
Cómo evitarlo:
  Implementar validaciones de entrada de datos en el servidor
  Utilizar controles SQL como LIMIT para evitar fuga masiva de registros en caso de una inyección
  Utilizar siempre que se pueda una API segura que evite el uso de un intérprete y proporcione una interfaz parametrizada

