using System;

public class Equipment : Item
{
    public enum EquipmentType { head, chest, legs, feet, weapon }; //dans le fichier json : utiliser {0,1,2,3} pour définir le type, pour les armes c'est fait dans le script creationArmes
    public EquipmentType type;
    public enum adjectifArmeTranchante { courbee , doubleTranchant,dentelee,epaisse,empoisonnee,deuxMains,aucun};
    public enum adjectifArmeEstoc { dentelee,garde,empoisonnee,aucun}
    public enum adjectifArmeContondante { deuxMain, lourde, pointe, atomique,aucun}
    public enum adjectifArmure { epaisse, fine, cuire, fer, mithril, cloutee, aucun }

    public int myEnumMemberCount = Enum.GetNames(typeof(adjectifArmure)).Length;

    public override void use()
    {
        EquipmentManager.instance.equip(this);
        removeFromInventory();
    }
}
