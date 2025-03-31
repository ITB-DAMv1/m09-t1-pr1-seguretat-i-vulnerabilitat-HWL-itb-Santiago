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



  2) Obre el següent enllaç (sql inseckten) i realitza un mínim de 7 nivells fent servir tècniques d’injecció SQL. 
Copia cada una de les sentències SQL resultant que has realitzat a cada nivell i comenta que has aconseguit.
Nivel 1:
SELECT username 
FROM users 
WHERE username ='jane' AND password ='e6afb454bb26efc6b24e9b7c017fc24f';

Nivel 2:
SELECT username
FROM users
WHERE username = 'jane'; DROP TABLE users--

Nivel 3:
SELECT username
FROM users
WHERE username = ''OR 1==1--

Nivel 4:
SELECT username
FROM users
WHERE username = '' or 1==1 limit 1--

Nivel 5:
SELECT product_id, brand, size, price
FROM shoes,
WHERE brand =''; SELECT * FROM users--

Nivel 6:
SELECT username
FROM users
WHERE username='' OR (SELECT salary AS username FROM staff WHERE firstname = 'Greta Maria')--

Nivel 7:




  3) L’empresa a la qual treballes desenvoluparà una aplicació web de venda d’obres d’art. Els artistes registren les seves obres amb fotografies, títol, descripció i preu.  Els clients poden comprar les obres i poden escriure ressenyes públiques dels artistes a qui han comprat. Tant clients com artistes han d’estar registrats. L’aplicació guarda nom, cognoms, adreça completa, dni i telèfon. En el cas dels artistes guarda les dades bancaries per fer els pagaments. Hi ha un tipus d’usuari Acount Manager que s’encarrega de verificar als nous artistes. Un cop aprovats poden pública i vendre les seves obres.

Ara es vol aplicar aplicant els principis  de seguretat per tal de garantir el servei i la integritat de les dades. T’han encarregat l'elaboració de part de les polítiques de seguretat. Elabora els següents apartats:

a) Definició del control d’accés: enumera els rols  i quin accés a dades tenen cada rol. 
Cliente: Puede ver y comprar obras de arte, escribir reseñas y modificar sus datos personales.

Artista: Puede registrarse, publicar obras, editarlas y ver sus ventas. No puede modificar los datos de pago sin verificación.

Account Manager: Puede verificar nuevos artistas, gestionar publicaciones y administrar reseñas sospechosas.

Administrador: Control total sobre la aplicación, incluido el acceso a todos los datos y gestión de permisos.

b) Definició de la política de contrasenyes: normes de creació, d’ús i canvi de contrasenyes. Raona si són necessàries diferents polítiques segons el perfil d’usuari.

Normas de creación:

Mínimo 12 caracteres.

Debe contener mayúsculas, minúsculas, números y caracteres especiales.

No puede ser igual a las últimas 5 contraseñas usadas.

Normas de uso y cambio:

Cambio obligatorio cada 6 meses.

Bloqueo de cuenta después de 5 intentos fallidos.

Para roles críticos (Account Manager y Administrador), doble factor de autenticación (2FA).

c) Avaluació de la informació: determina quin valor tenen les dades que treballa l'aplicació. Determina com tractar les dades més sensibles. Quines dades encriptaries?

Valor de los datos:

Datos personales (nombre, DNI, dirección, teléfono) tienen un valor alto por la protección de privacidad.

Datos bancarios de los artistas tienen un valor crítico.

Tratamiento de datos sensibles:

Los datos bancarios se encriptan con AES-256.

Las contraseñas se guardan con hash y sal (SHA-256 o bcrypt).

No se guardan DNI o teléfonos en texto plano, se cifran con AES.


4) En el control d’accessos, existeixen mètodes d’autenticació basats en tokens. Defineix l’autenticació basada en tokens. Quins tipus hi ha? Com funciona mitjançant la web? Cerca llibreries .Net que ens poden ajudar a implementar autenticació amb tokens.
   ¿Qué es? Método de autenticación donde el usuario recibe un token al validarse, que se usa para futuras peticiones.

Tipos de tokens:

JWT (JSON Web Token): Ligero y seguro, contiene la información del usuario.

OAuth 2.0: Se utiliza para autenticación en aplicaciones de terceros.

SAML: Más común en entornos empresariales.

Funcionamiento en web:

El usuario inicia sesión con usuario y contraseña.

El servidor valida las credenciales y genera un JWT.

El cliente envía el JWT en cada petición HTTP para autenticarse.

Librerías .NET para autenticación con tokens:

Microsoft.AspNetCore.Authentication.JwtBearer

IdentityServer4

Auth0 SDK for .NET

