NamuService:
Servicio REST implementado con Web API, todas las llamadas son asíncronas con Entity Framework. Hay un read only dentro del proyecto de visual studio.

NamuClient:
- Cliente que consume el servicio (limitadamente de parte del cliente, aunque el servicio funciona bien), con MVC Angular y un tema Bootstrap.
- La idea de arquitectura es un modelo MVC y MVVM con Angular.
- El login no está implementado, solo previsto con Identity.