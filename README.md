
# Formas Geométricas

### El desafio

Tenemos un método que genera un reporte en base a una colección de formas geométricas, procesando algunos datos para presentar información extra. La firma del método es:

```csharp
public static string Imprimir(List<FormaGeometrica> formas, int idioma)
```
Al mismo tiempo, encontramos muy díficil el poder agregar o bien una nueva forma geométrica, o imprimir el reporte en otro idioma. Nos gustaría poder dar soporte para que el usuario pueda agregar otros tipos de formas u obtener el reporte en otros idiomas, pero extender la funcionalidad del código es muy doloroso. ¿Nos podrías dar una mano a refactorear la clase FormaGeometrica? Dentro del código encontrarás un TODO con nuevos requerimientos a satisfacer una vez completada la refactorización.

Acompañando al proyecto encontrarás una serie de tests unitarios (librería NUnit) que describen el comportamiento del método Imprimir. **Se puede modificar cualquier cosa del código y de los tests, con la única condición que los tests deben pasar correctamente al entregar la solución.** 

### Salida en pantalla de la aplicación

Ejecutando ConsoleApp aparecerá en consola la siguiente salida en tres idiomas:

Reporte de Formas
1 Círculo | Perímetro: 12.57 | Área: 12.57 |
1 Rectangulo | Perímetro: 8 | Área: 4 |
1 Cuadrado | Perímetro: 8 | Área: 4 |
1 Triángulo | Perímetro: 6 | Área: 1.73 |
1 Trapecio | Perímetro: 16 | Área: 8 |
TOTAL :
5 Formas |Perímetro: 50.57 | Área: 30.3 |


Forms Report
1 Circle | Perimeter: 12.57 | Area: 12.57 |
1 Rectangle | Perimeter: 8 | Area: 4 |
1 Square | Perimeter: 8 | Area: 4 |
1 Triangle | Perimeter: 6 | Area: 1.73 |
1 Trapeze | Perimeter: 16 | Area: 8 |
TOTAL :
5 Shapes |Perimeter: 50.57 | Area: 30.3 |


Rapporto sui moduli
1 Cerchio | Perimetro: 12.57 | La zona: 12.57 |
1 Rettangolo | Perimetro: 8 | La zona: 4 |
1 Piazza | Perimetro: 8 | La zona: 4 |
1 Triangolo | Perimetro: 6 | La zona: 1.73 |
1 Trapezio | Perimetro: 16 | La zona: 8 |
TOTALE :
5 Forme |Perimetro: 50.57 | La zona: 30.3 |

Si quieres ver la salida en formato HTML una de las formas que puedes aplicar es:
- copiar la salida de la ventana de comandos y pegarlo en un archivo de block de notas
- guardar el archivo con extension HTML y luego abrirlo.

### Notas

Version de Visual Studio: 2019
Sobre .NET Framework 4.6.2

Ing. Daniel Perelman
Junio 2023