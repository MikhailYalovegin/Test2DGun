using UnityEngine;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Characters.Configs
{
  [CreateAssetMenu(fileName = "Enemy_CATEGORY_TYPE_NAME", menuName = "Dev/Enemies/Enemy")]
  public class EnemyConfig : ScriptableObject
  {
    [SerializeField] private CharacterBase _character;

    public CharacterBase Character => _character;
  }
}