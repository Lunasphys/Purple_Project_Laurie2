

==========> NAMI'S TRIAL <==========

PROJET

Bonjour ! 
Je me présente, Laurie et je suis en seconde année Informatique à l'école YNOV sur Aix-En -Provence.
Voici le premier projet style Jeux-Vidéo en C# sur Windows Form. 
Après plusieurs semaines d'apprentissage et de prise de tête, j'ai l'honneur de vous présenter NAMI'S TRIAL.

CHOIX DU JEU

Pour ce projet, plusieurs choix nous ont été donnés. En effet, nous pouvions choisir de réaliser un platformer, un snake, un doodle-jump, un casse-bric ou bien 
encore un pong. 
Ce choix n'a pas été cornélien pour ma part. Malgré que mon enfance ait été bercé par les spaces invaders ou snake (nokia on te salue), le style platformer est celui sur lequel j'avais passé le plus clair de mon temps. Sans parler d'affinité, le platformer est aussi le format qui pour moi, représentait un véritable challenge ainsi qu'une personnalisation beaucoup plus poussée. Après le choix du style, j'avais déjà en tête le petit jeu que je souhaitais créer.

OBJECTIFS

Tout d'abord, cela a été un très bon entrainement pour se familiariser avec le C# d'une manière fun et amusante. J'ai été très investie.
Mes objectifs de base étaient tout sauf prétencieux. Je souhaitais simplement avoir un gameplay assez smooth et développer un jeu qui me plaisait. 
Les règles établies étaient les suivantes : déplacement, score, collision, condition de WIN/LOSE.
Se dire que j'ai réussi à faire ça est en soit un achèvement en lui-même (Une petite fierté si je puis dire ainsi).
C'est enfin un projet que je peux partager avec mes amis, ma famille sans qu'ils soient rebutés par des lignes de codes (enfin !). C'est un projet qui se partage et dont il est plus facile de discuter dans mon cercle. 
Objectif du jeu : Récupérer toutes les croquettes avant de rentrer à la niche sans mourir. 

DIFFICULTÉS/RÉSOLUTION

Avant de commencer son développement, j'étais loin de m'imaginer TOUS les problèmes que j'allais rencontrer... 
Dans un premier temps l'IDE Visual Studio.

Il me semble avoir avorté de 2 projets parce que j'avais des erreurs incompréhensibles. La navigation était très différente de ce que j'avais pu rencontrer précédemment. Après réfléxion, il s'avère qu'après plusieurs heures dessus, c'était juste une mauvaise compréhension des fonctionnalités de Windows Form. Comment ouvrir la fenêtre designer, comment ouvrir celle contenant le code, retrouver la toolbox. En soit des choses qui me  semblent enfantines maintenant mais qui m'ont fait perdre pas mal de temps. J'ai aussi voulu switcher sur Rider, perte encore CONSIDERABLE de temps (nouvelles erreurs, suppressions de toutes les images de mes pictureBox, bug de l'IDE en lui-même et j'en passe...).

Ensuite il y a eu les collisions, qui ont été un casse-tête pour pas mal de monde me semble t'il. Au début je me suis dis que c'était assez simple. Après avoir regardé 
plusieurs tuto, il suffisait d'utiliser le intersectWith et le Bonds et le tour était joué. Que nenni ! Cette méthode est bonne si l'on souhaite seulement marcher
sur la plateforme. Le problème était que si le joueur avait le malheur de toucher n'importe quel autre côté de cette plateforme, il se retrouvait forcément dessus 
quoi qu'il arrive. Il a donc fallut supprimer cette facilité et tout faire côté par côté. Je vous avoue que cela a été plutôt pénible, avec BEAUCOUP d'heures de 
recherche ainsi que de triturage de cerveau sur une feuille en papier. A force de persévérance on y arrive ! 

Passé cet obstacle, le fait que mon personnage glitch sévérement me tracassait. Après un certain temps j'ai compris que cela venait de mes déplacements et de la
gravité. J'ai donc essayé de les refaire sans succès. Pour réduire cet effet j'ai simplement réduit la gravité lors de la chute hors du saut. Ce qui donne 
cet effet plus lent lors de la chute (chose qui n'arrive pas lors d'une chute après un saut). J'ai rajouté un +5 sur l'axe Y lorsque le jump est faux (à +10 plus de glitch, mais aussi pas de chute malheureusement).

J'avais aussi un problème de plusieurs sauts possibles, mais après de nombreux essais, il s'agissait simplement de retirer l'effet lors du KeyIsUp. 
Autre problème non réglé, donc modifié. Le fait que ma mémoire sature lorsque le jeu est en GameOver. J'ai voulu créer une pictureBox animée lors d'une mort ou du non accomplissement des objectifs, seulement vu qu'il était stocké en non visible, au bout d'un moment la mémoire sature et plante.
Malhereusement je m'en suis rendu compte le 31/10/2022 donc... au dernier moment. Si j'avais eu plus de temps, je sais que j'aurais dû créer la pictureBox au moment de la mort puis la détruire lors du Restart. 

Création des assets. Au début j'ai voulu créer mes assets moi-même... c'était pas mal, mais comparé à l'existant j'ai vite abandonné cette idée. Malgré que certaines créations soient présentes dans les ressources du jeu.


THEME DU JEU

Le thème abordé n'est pas si profond, c'est un jeu légé. 
Pour faire simple, Nami est mon chien. C'est une femelle Shiba Inu de 4 ans et demi. Elle adore les friandises (et particulièrement le poulet, d'où la super prime de +10 en croquette pour le poulet) et a une peur bleue des chats. Elle s'était faite attaquée par l'un d'eux lors d'une promenade en forêt avant sa première année, et depuis c'est sa phobie. 
Pour rester dans cette légereté j'ai opté pour des couleurs vives, et un style un peu cartoon. 

FEATURES

Saut unique (de la plateforme ou dans le vide)
Score
Ennemis
Mort si le personnage tombe dans le vide
Plateforme mouvante
Ennemis mobile
Game Over
Restart
Limite de mouvement au screen gauche et droite (haut non limité)
Collision de chaque côté des plateformes
