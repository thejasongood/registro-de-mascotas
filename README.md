# Registro de Mascotas

Programa realizado en C# para llevar un registro básico de mascotas de una veterinaria.

## ¿Qué hace?

El programa permite:

- Agregar mascotas.
- Registrar nombre, especie y peso.
- Mostrar todas las mascotas registradas.
- Buscar mascotas por especie.
- Clasificar la mascota según su peso.
- Guardar los datos en un archivo `mascotas.csv`.
- Cargar los datos guardados al iniciar el programa.

## Datos que se registran

Cada mascota tiene:

- ID
- Nombre
- Especie
- Peso

Si el peso es mayor a 25 kg se muestra como **Raza grande**.  
Si es de 25 kg o menos se muestra como **Raza pequeña/mediana**.

## Instrucciones

1. Ejecutar el programa desde Visual Studio.
2. Seleccionar una opción del menú.
3. Para agregar una mascota, ingresar su nombre, especie y peso.
4. En la opción de listar se pueden ver las mascotas registradas.
5. En buscar por especie se puede escribir una especie para encontrar coincidencias.
6. Al seleccionar salir, los datos se guardan automáticamente en `mascotas.csv`.
7. Al volver a iniciar el programa, los datos guardados se cargan nuevamente.

## Ejemplo

```text
Mascota 1: Firulais (Perro) - 30.5 kg - Raza grande
Mascota 2: Michi (Gato) - 4.2 kg - Raza pequeña/mediana
