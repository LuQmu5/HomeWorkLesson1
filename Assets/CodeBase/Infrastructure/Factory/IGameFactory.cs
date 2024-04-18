using System.Threading.Tasks;
using UnityEngine;

public interface IGameFactory : IService
{
    public void CreateHero(Vector3 at);
    public void CreateHud();
}
