PROJET

Bonjour ! 
Je me présente, Laurie et je suis en seconde année Informatique à l'école YNOV sur Aix-En -Provence.
Voici le premier projet projet style Jeux-Vidéo en C# sur Windows Form. 
Après plusieurs semaines d'apprentissage et de prise de tête, j'ai l'honneur de vous présenter NAMI'S TRIAL 

CHOIX DU JEU

Pour ce projet, plusieurs choix nous ont été donnés. En effet, nous pouvions choisir de réaliser un platformer, un snake, un doodle-jump, un casse-bric ou bien 
encore un pong. 
Ce choix n'a pas été cornélien pour ma part. Malgré que mon enfance ait été bercé par les spaces invaders ou snake (nokia on te salue), le style platformer est celui sur
lequel j'avais passé le plus clair de mon temps. Sans parler d'affinité, le platformer est aussi le format qui pour moi, représentait un véritable challenge ainsi qu'une
personnalisation beaucoup plus poussée. Après le choix du style, j'avais déjà en tête le petit jeu que je souhaitais créer.

OBJECTIFS

Tout d'abord, cela a été un très bon entrainement pour se familiariser avec le C# d'une manière fun, amusante mais l'investissement dedans.
Mes objectifs de bases étaient tout sauf prétencieux. Je souhaitais simplement avoir un gameplay assez smooth et développer un jeu qui me plaisait. 
Les règles établies étaient les suivantes : déplacement, score, collision, condition de WIN/LOSE
Se dire que j'ai réussi à faire ça est en soit un achievement en lui-même. (une petite fierté si je puis dire aussi) 
C'est enfin un projet que je peux partager à mes amis/famille sans qu'ils soient rebutés par des lignes de codes. (enfin !) C'est un projet qui se partage et dont 
il est plus facile de discuter dans mon cercle social. 

expliquer les difficultés rencontrées / comment on les a réglées

Avant de commencer sont dévloppement, j'étais loin de m'imaginer TOUS les problèmes que j'ai rencontré. 
Dans un premier temps l'IDE qu'est Visual Studio. Il me semble avoir avorté de 2 projets parce que j'avais des erreurs incompréhensibles. La navigation était
très différente de ce que j'avais pu rencontrer précédemment. Après réfléxion, il s'avère qu'après plusieurs heures dessus, c'était juste une mauvaise compréhension
des fonctionnalités de Windows Form. Comment ouvrir la fenêtre designer, comment ouvrir celle contenant le code, retrouver la toolbox. En soit des choses qui me 
semble enfantine maintenant mais qui m'ont fait perdre pas mal de temps. J'ai aussi voulu switcher sur Rider, perte encore CONSIDERABLE de temps. (nouvelles erreurs, 
suppressions de toutes les images de mes pictureBox, bug de l'IDE en lui-même et j'en passe...) 
Ensuite il y a eu les collisions, qui a été un casse-tête pour pas mal de monde me semble t'il. Au début je me suis dis que c'était assez simple. Après avoir regardé 
plusieurs tuto, il suffisait d'utiliser le intersectWith et le Bonds et le tour était joué. Que nenni ! Cette méthode est bonne si l'on souhaite seulement marcher
sur la plateforme. Le probleme était que si le jouer avait le malheur de toucher n'importe quel autre côté de cette plateforme, il se retrouverait forcément dessus 
quoi qu'il arrive. Il a donc fallut supprimer cette facilité et tout faire côté par côté. Je vous avoue que cela a été plutôt pénible, avec BEAUCOUP d'heure de 
recherche ainsi que de triturage de cerveau sur une feuille en papier. A force de persévérance on y arrive ! 
Passé cet obstacle, le fait que mon personnagle glitch sévérement me tracassait. Après un certain temps j'ai compris que cela venait de mes déplacements et de la
gravité. J'ai donc essayé de les refaire sans succés. Pour réduire cet effet j'ai simplement réduit cet effet lors de la chute hors du saut. Ce qui donne 
cet effet plus lent lors de la chute. (chose qui n'arrive pas lors d'une chute après un saut)

d
expliquer le thème du jeu
expliquer les features
