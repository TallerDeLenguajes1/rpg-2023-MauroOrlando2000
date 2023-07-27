# rpg-2023-MauroOrlando2000
rpg-2023-MauroOrlando2000 created by GitHub Classroom

##Proyecto final - Taller de Lenguajes I
Este es un juego de pelea 1vs1.  
Al comenzar, el juego intenta leer el archivo "Personajes.json", si lo encuentra da la opcion de leer los personajes dentro de este Json o si crear personajes nuevos.  


Los personajes se puede crear tanto por un algoritmo creado en el juego, o de manera online a través de una API.  
El juego se desarrolla como un modo torneo. 6 Personajes son elegidos al azar y juegan directamente en cuartos de final, los 4 restantates jugarán dos peleas en octavos.  


Los personajes creados bajo la clase "FabricaDePersonajes" tienen datos informativos, como el nombre, apodo, fecha de nacimiento, etc, y datos estadísticos, como su ataque, velocidad, agilidad, etc.  
Cada personaje puede tener una de las 7 clases: Saber, Lancer, Archer, Rider, Caster, Assassin, y Berserker. Esto afecta al gameplay, ya que cada clase tiene ventajas y desventajas contra otras (como se muestra [Aqui](https://th.bing.com/th/id/OIP.G8DRoO_vILJ27liKWMSFvwHaES?pid=ImgDet&rs=1]))  


Antes de una pelea, uno puede elegir si quiero formar parte de la pelea y tomar el control de alguno de los dos personajes.  
En la pelea, el personaje con la mayor velocidad atacará primero.  
Tienen dos modos de atacar: un ataque básico, y su habilidad.  
El ataque basico usa el ataque y nivel del atacante, la defensa del oponente, y un número aleatorio entre 70 y 100 para calcular el daño. El motivo del numero aleatorio es para que si se usa repetidamente un ataque, no de siempre los mismos números.  
La habilidad depende de la clase. No es recomendable usar repetidamente las habilidades ya que estas traen consecuencias en forma de reducción de estadisticas o vida.  


Cuando la vida de uno de los personajes llega a 0, este pierde la pelea, y el otro la gana pasando a la siguiente ronda, y obteniendo una recompensa como ataque, defensa, velocidad y agilidad, o salud.  
El juego se desarrolla como si fuera la llave de un torneo.  
Al finalizar el juego, el ultimo personaje en pie se declara ganador y se lo envia a un Json.

La API es generada a traves de [esta web](https://randomapi.com/api/e9a3b0d847609bbda960c8a85c1fd3c7).  
Pagina para crear APIs en java: https://randomapi.com/

PROYECTO REVISADO
