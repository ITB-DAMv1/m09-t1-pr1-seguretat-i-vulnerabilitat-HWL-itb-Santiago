[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/S9WTUTwx)

# Vulnerabilidades OWASP - Descripción y Medidas Preventivas

La organización OWASP (Open Web Application Security Project) actualizó en 2021 su lista de las 10 vulnerabilidades más comunes en aplicaciones web. A continuación, se explican tres de estas vulnerabilidades junto con su impacto y las medidas para prevenirlas:

## 1.1 Pérdida de Control de Acceso

**Descripción:**  
Los usuarios pueden actuar fuera de los permisos asignados, accediendo a información o funcionalidades que no deberían.

**Impacto:**  
Los atacantes pueden acceder a información confidencial, modificar registros o eliminar datos de otras cuentas, lo que puede comprometer la integridad y la privacidad de los datos.

**Medidas Preventivas:**
- Denegar acceso a recursos por defecto, a excepción de los públicos.
- Asegurarse de que los usuarios no puedan crear, modificar o eliminar cualquier dato sin autorización.
- Implementar autenticación basada en tokens, como JWT, con tokens de corta duración.
- Invalidar los identificadores de sesión al cerrar sesión.

## 1.2 Inyección SQL (SQL Injection)

**Descripción:**  
Los atacantes pueden introducir código SQL malicioso a través de entradas de usuario no validadas, con el objetivo de manipular la base de datos.

**Impacto:**  
Puede resultar en el acceso no autorizado a la base de datos, el robo de información confidencial, la alteración de datos y la elevación de privilegios.

**Medidas Preventivas:**
- Validar siempre las entradas del usuario en el servidor.
- Utilizar consultas parametrizadas para evitar la inyección de código.
- Limitar el número de registros devueltos mediante el uso de `LIMIT` para evitar filtraciones masivas de datos.

## 1.3 Exposición de Datos Sensibles

**Descripción:**  
La exposición de datos sensibles, como contraseñas o información financiera, debido a la falta de cifrado o medidas de protección adecuadas.

**Impacto:**  
El robo de datos sensibles puede llevar a un fraude financiero, robo de identidad o daños irreparables a la reputación de la empresa.

**Medidas Preventivas:**
- Cifrar todos los datos sensibles con algoritmos fuertes, como AES-256 para datos bancarios y contraseñas.
- Utilizar hashing y salting para almacenar contraseñas de forma segura.
- Implementar el uso de HTTPS para cifrar la transmisión de datos.

# 3. Prácticas de Seguridad en una Aplicación Web de Venta de Obras de Arte

A continuación, se presentan las políticas de seguridad que se deben implementar en una aplicación web de venta de obras de arte, que involucra a artistas, clientes y administradores.

## 3.1 Definición del Control de Acceso

Los roles de usuario en la aplicación son los siguientes:

- **Cliente:**
  - Acceso: Ver y comprar obras de arte, escribir reseñas y modificar sus datos personales.

- **Artista:**
  - Acceso: Registrarse, publicar y editar obras de arte, consultar ventas. No puede modificar sus datos bancarios sin verificación.

- **Account Manager:**
  - Acceso: Verificar nuevos artistas, gestionar publicaciones de arte y reseñas sospechosas.

- **Administrador:**
  - Acceso: Control total sobre la aplicación, gestión de todos los datos y permisos.

## 3.2 Política de Contraseñas

Las políticas de contraseñas garantizan la protección de cuentas de usuario, especialmente en roles críticos como Account Manager y Administrador.

**Normas de Creación:**
- Mínimo 12 caracteres.
- Debe incluir mayúsculas, minúsculas, números y caracteres especiales.
- No puede ser igual a las últimas 5 contraseñas utilizadas.

**Normas de Uso y Cambio:**
- Cambio obligatorio cada 6 meses.
- Bloqueo de cuenta después de 5 intentos fallidos de inicio de sesión.
- Para roles críticos (Account Manager y Administrador), se requiere doble factor de autenticación (2FA).

## 3.3 Evaluación de la Información y Tratamiento de Datos Sensibles

**Valor de los datos:**
- Los datos personales (nombre, DNI, dirección, teléfono) tienen un alto valor por su implicación en la privacidad.
- Los datos bancarios de los artistas tienen un valor crítico.

**Tratamiento de los Datos Sensibles:**
- Los datos bancarios deben ser cifrados con AES-256.
- Las contraseñas deben almacenarse con hashing y salting (SHA-256 o bcrypt).
- El DNI y teléfono se cifran con AES para proteger la privacidad.

# 4. Autenticación Basada en Tokens

La autenticación basada en tokens es una técnica que permite al usuario autenticarse y recibir un token para utilizar en futuras peticiones a la aplicación.

## Tipos de Tokens:

- **JWT (JSON Web Token):**
  - Ligero y seguro.
  - Contiene la información del usuario y se utiliza ampliamente para sesiones.

- **OAuth 2.0:**
  - Utilizado para aplicaciones de terceros (autenticación delegada).

- **SAML (Security Assertion Markup Language):**
  - Utilizado en entornos empresariales para el intercambio seguro de información de autenticación.

## Funcionamiento en la Web:

1. El usuario inicia sesión con sus credenciales.
2. El servidor valida las credenciales y genera un JWT.
3. El cliente almacena el JWT y lo incluye en las cabeceras de cada solicitud HTTP subsiguiente para autenticarse.

## Librerías .NET para Implementación de Autenticación con Tokens:
- **Microsoft.AspNetCore.Authentication.JwtBearer**
- **IdentityServer4**
- **Auth0 SDK for .NET**

