feature : implémentation de la simulation de carte aux trésor

#Le chemin des dossiers peut être configuré via l’AppConfig de l’application. 
#Des fichiers d’entrée d’exemple sont inclus afin de faciliter les tests et l’utilisation initiale.

#La solution est composée de trois projets :
une application console (Carte_aux_tresors) servant de point d’entrée,
une bibliothèque de classes (Core) contenant la logique métier,
un projet dédié aux tests unitaires.

L’ensemble des projets a été développé en .NET 8, et les tests unitaires utilisent xUnit.