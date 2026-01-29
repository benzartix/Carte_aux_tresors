using Core.Domain;


namespace Core.Service
{
    public class MovementService
    {
        private readonly Map _map;

        public MovementService(Map map)
        {
            _map = map;
        }

        public void Movement(Aventurier aventurier)
        {
            var targetPosition = aventurier.Position.Move(aventurier.Orientation);

            // Hors carte  bloqué
            if (!_map.IsInside(targetPosition))
                return;

            // Montagne  bloqué
            if (_map.GetCellule(targetPosition).Terrain == TerrainType.Mountagne)
                return;

            // Déplacement autorisé
            aventurier.MouvementValide();

            //Collecte du trésor (1 seul)
            var cell = _map.GetCellule(aventurier.Position);
            if (cell.nbTresors > 0)
            {
                cell.nbTresors--;
                aventurier.CollectTreasure();
            }
        }
    }
}
