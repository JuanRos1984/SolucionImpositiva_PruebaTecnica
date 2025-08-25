# SolucionImpositiva_PruebaTecnica
Proyecto de consulta de contribuyentes y comprobantes fiscales para prueba técnica.

Proyecto desarrollado con arquitectura **Onion**, utilizando el enfoque **Database First** y procedimientos almacenados para una gestión eficiente de datos.
Este proyecto está diseñado para ser limpio, escalable y fácilmente testeable.

---

## Arquitectura

El proyecto sigue el patrón **Onion Architecture**, que promueve la separación de responsabilidades y facilita el mantenimiento.

- **Dominio**: Entidades y excepciones de negocio.
- **Aplicación**: Servicios, DTOs y lógica de negocio.
- **Infraestructura**: Repositorios y acceso a datos vía Entity Framework.
- **API**: Controladores y configuración de endpoints.

---

## Base de Datos

- Enfoque: **Database First**
- Motor de bases de datos: SQL Server
- Acceso a datos mediante **procedimientos almacenados**
- Se incluye el script SQL en el repositorio:  
  `Script DB prueba tecnica.sql`

---

## Pruebas Unitarias

El proyecto incluye una suite de pruebas unitarias para:

- Servicios de aplicación (`ContribuyenteServicio`, `ComprobanteServicio`)
- Controladores (`ContribuyenteController`, `ComprobanteController`)

Las pruebas cubren:

- Casos exitosos
- Excepciones controladas
- Excepciones inesperadas
- Validación de entrada

Frameworks utilizados:
- [xUnit](https://xunit.net/)
- [Moq](https://github.com/moq/moq4)

---

## Logging

Los errores se registran automáticamente en un archivo de log ubicado en la carpeta Logs, en la raíz del proyecto API. Esto permite trazabilidad sin depender de servicios externos.

---

## Nota

No olvide configurar la cadena de conexión en `appsettings.json` con los datos del servidor donde va a ejecutar el script de la BD

---

## 📂 Estructura del proyecto
