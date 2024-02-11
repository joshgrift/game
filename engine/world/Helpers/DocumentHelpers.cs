using Game.Datastore;

namespace Game.World
{
  public static class DocumentHelpers
  {
    public static WorldComponent GetWorldComponent(Document document)
    {
      List<Entity> worldEntities = document.GetEntities(typeof(WorldComponent));

      if (worldEntities.Count != 1)
        throw new Exception($"Incorrect number of worldComponents: {worldEntities.Count}");

      return worldEntities[0].GetComponent<WorldComponent>()!;
    }

    public static string GetPlayerName(Document document, Guid player)
    {
      var playerEntity = document.GetByGuid(player);

      if (playerEntity == null)
        return "Not an Entity";

      var playerComponent = playerEntity.GetComponent<Player>();

      if (playerComponent == null)
        return "Not a player";

      return playerComponent.Name;
    }
  }
}