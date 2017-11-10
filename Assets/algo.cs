using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Microsoft.CSharp;
using Pathfinding.Serialization.JsonFx;
using System.Reflection;
using Newtonsoft.Json;
using System.Linq;
using System.Text;

public class algo : MonoBehaviour
{
    // Use this for initialization
    List<GameObject> tableObjects = new List<GameObject>();

    void Start()
    {
        Debug.Log(findHigherLevelItem(new List<string>(new string[] {"Sheen", "Phage", "Stinger" })));
        Instantiate(GameObject.Find("Sheen"), transform.position, transform.rotation);
        Instantiate(GameObject.Find("Stinger"), transform.position, transform.rotation);
        Instantiate(GameObject.Find("Phage"), transform.position, transform.rotation);
    }

    String findHigherLevelItem(List<String> items)
    {
        string item_json = @"
            {""Thornmail"": [""Bramble Vest"", ""Ruby Crystal"", ""Warden's Mail""], ""Banner of Command"": [""Aegis of the Legion"", ""Raptor Cloak""], ""The Lightbringer"": [""Wicked Hatchet"", ""Cloak of Agility""], ""Crystalline Bracer"": [""Ruby Crystal"", ""Rejuvenation Bead""], ""Sanguine Blade"": [""Pickaxe"", ""Vampiric Scepter""], ""Essence Reaver"": [""B. F. Sword"", ""Caulfield's Warhammer"", ""Cloak of Agility""], ""Spectre's Cowl"": [""Ruby Crystal"", ""Null-Magic Mantle""], ""The Bloodthirster"": [""B. F. Sword"", ""Long Sword"", ""Vampiric Scepter""], ""Tiamat"": [""Long Sword"", ""Rejuvenation Bead"", ""Long Sword""], ""Blade of the Ruined King"": [""Bilgewater Cutlass"", ""Recurve Bow""], ""Enchantment: Cinderhulk"": [""Bami's Cinder"", ""Stalker's Blade""], ""Zeal"": [""Brawler's Gloves"", ""Dagger""], ""Dervish Blade"": [""Quicksilver Sash"", ""Stinger""], ""Seeker's Armguard"": [""Cloth Armor"", ""Amplifying Tome"", ""Cloth Armor""], ""Luden's Echo"": [""Needlessly Large Rod"", ""Aether Wisp""], ""Randuin's Omen"": [""Warden's Mail"", ""Giant's Belt""], ""Overlord's Bloodmail"": [""Giant's Belt"", ""Crystalline Bracer""], ""Youmuu's Ghostblade"": [""Caulfield's Warhammer"", ""Serrated Dirk""], ""Eye of the Equinox"": [""Sightstone"", ""Targon's Brace""], ""Hextech Protobelt-01"": [""Hextech Revolver"", ""Kindlegem""], ""Bilgewater Cutlass"": [""Vampiric Scepter"", ""Long Sword""], ""Frostfang"": [""Spellthief's Edge"", ""Faerie Charm""], ""Wit's End"": [""Recurve Bow"", ""Negatron Cloak"", ""Dagger""], ""Sunfire Cape"": [""Chain Vest"", ""Ruby Crystal"", ""Bami's Cinder""], ""Nashor's Tooth"": [""Stinger"", ""Fiendish Codex""], ""Hextech Gunblade"": [""Bilgewater Cutlass"", ""Hextech Revolver""], ""Frozen Heart"": [""Warden's Mail"", ""Glacial Shroud""], ""Frozen Mallet"": [""Jaurim's Fist"", ""Giant's Belt""], ""The Black Cleaver"": [""Phage"", ""Kindlegem""], ""Enchantment: Bloodrazor"": [""Recurve Bow"", ""Stalker's Blade""], ""Gargoyle Stoneplate"": [""Chain Vest"", ""Stopwatch"", ""Negatron Cloak""], ""Ruby Sightstone"": [""Sightstone"", ""Ruby Crystal""], ""Frost Queen's Claim"": [""Frostfang"", ""Blasting Wand""], ""Eye of the Watchers"": [""Sightstone"", ""Frostfang""], ""Adaptive Helm"": [""Null-Magic Mantle"", ""Spectre's Cowl"", ""Rejuvenation Bead""], ""Targon's Brace"": [""Relic Shield"", ""Rejuvenation Bead""], ""Manamune"": [""Tear of the Goddess"", ""Pickaxe""], ""Warmog's Armor"": [""Giant's Belt"", ""Kindlegem"", ""Crystalline Bracer""], ""Death's Dance"": [""Vampiric Scepter"", ""Pickaxe"", ""Caulfield's Warhammer""], ""Rabadon's Deathcap"": [""Blasting Wand"", ""Needlessly Large Rod"", ""Amplifying Tome""], ""Iceborn Gauntlet"": [""Sheen"", ""Glacial Shroud""], ""Spirit Visage"": [""Spectre's Cowl"", ""Kindlegem""], ""Forbidden Idol"": [""Faerie Charm"", ""Faerie Charm""], ""Dead Man's Plate"": [""Chain Vest"", ""Giant's Belt""], ""Berserker's Greaves"": [""Boots of Speed"", ""Dagger""], ""Ardent Censer"": [""Forbidden Idol"", ""Aether Wisp""], ""Ravenous Hydra"": [""Tiamat"", ""Vampiric Scepter"", ""Pickaxe""], ""Guardian Angel"": [""B. F. Sword"", ""Cloth Armor"", ""Stopwatch""], ""Mikael's Crucible"": [""Chalice of Harmony"", ""Forbidden Idol""], ""Hexdrinker"": [""Long Sword"", ""Null-Magic Mantle""], ""Athene's Unholy Grail"": [""Fiendish Codex"", ""Chalice of Harmony""], ""Archangel's Staff (Quick Charge)"": [""Tear of the Goddess (Quick Charge)"", ""Needlessly Large Rod""], ""Rylai's Crystal Scepter"": [""Blasting Wand"", ""Amplifying Tome"", ""Ruby Crystal""], ""Hextech GLP-800"": [""Catalyst of Aeons"", ""Hextech Revolver""], ""Arcane Sweeper"": [""Glacial Shroud"", ""Kindlegem""], ""Archangel's Staff"": [""Tear of the Goddess"", ""Needlessly Large Rod""], ""Jaurim's Fist"": [""Long Sword"", ""Ruby Crystal""], ""Lord Van Damm's Pillager"": [""Caulfield's Warhammer"", ""Jaurim's Fist""], ""Eye of the Oasis"": [""Sightstone"", ""Nomad's Medallion""], ""Aegis of the Legion"": [""Null-Magic Mantle"", ""Cloth Armor""], ""Face of the Mountain"": [""Targon's Brace"", ""Kindlegem""], ""Chalice of Harmony"": [""Faerie Charm"", ""Null-Magic Mantle"", ""Faerie Charm""], ""Enchantment: Warrior"": [""Caulfield's Warhammer"", ""Tracker's Knife""], ""Catalyst of Aeons"": [""Ruby Crystal"", ""Sapphire Crystal""], ""Lost Chapter"": [""Amplifying Tome"", ""Sapphire Crystal""], ""Zhonya's Hourglass"": [""Seeker's Armguard"", ""Stopwatch"", ""Fiendish Codex""], ""Glacial Shroud"": [""Sapphire Crystal"", ""Cloth Armor""], ""Void Staff"": [""Blasting Wand"", ""Amplifying Tome""], ""Raptor Cloak"": [""Rejuvenation Bead"", ""Cloth Armor""], ""Mercurial Scimitar"": [""Quicksilver Sash"", ""Pickaxe"", ""Vampiric Scepter""], ""Talisman of Ascension"": [""Nomad's Medallion"", ""Raptor Cloak""], ""Ninja Tabi"": [""Boots of Speed"", ""Cloth Armor""], ""Mortal Reminder"": [""Last Whisper"", ""Executioner's Calling""], ""Redemption"": [""Forbidden Idol"", ""Crystalline Bracer""], ""Liandry's Torment"": [""Haunting Guise"", ""Blasting Wand""], ""Locket of the Iron Solari"": [""Aegis of the Legion"", ""Null-Magic Mantle""], ""Hextech Revolver"": [""Amplifying Tome"", ""Amplifying Tome""], ""Infinity Edge"": [""B. F. Sword"", ""Pickaxe"", ""Cloak of Agility""], ""Knight's Vow"": [""Kindlegem"", ""Chain Vest""], ""Guinsoo's Rageblade"": [""Blasting Wand"", ""Recurve Bow"", ""Pickaxe""], ""Lord Dominik's Regards"": [""Last Whisper"", ""Giant Slayer""], ""Ohmwrecker"": [""Raptor Cloak"", ""Kindlegem""], ""Manamune (Quick Charge)"": [""Tear of the Goddess (Quick Charge)"", ""Pickaxe""], ""Mercury's Treads"": [""Boots of Speed"", ""Null-Magic Mantle""], ""Banshee's Veil"": [""Fiendish Codex"", ""Null-Magic Mantle"", ""Blasting Wand""], ""Trinity Force"": [""Stinger"", ""Sheen"", ""Phage""], ""Morellonomicon"": [""Fiendish Codex"", ""Amplifying Tome"", ""Lost Chapter""], ""Haunting Guise"": [""Ruby Crystal"", ""Amplifying Tome""], ""Lich Bane"": [""Sheen"", ""Aether Wisp"", ""Blasting Wand""], ""Edge of Night"": [""Pickaxe"", ""Serrated Dirk"", ""Ruby Crystal""], ""Nomad's Medallion"": [""Rejuvenation Bead"", ""Ancient Coin""], ""Duskblade of Draktharr"": [""Serrated Dirk"", ""Caulfield's Warhammer""], ""Maw of Malmortius"": [""Hexdrinker"", ""Caulfield's Warhammer""], ""Righteous Glory"": [""Glacial Shroud"", ""Crystalline Bracer""], ""Titanic Hydra"": [""Tiamat"", ""Ruby Crystal"", ""Jaurim's Fist""], ""Zz'Rot Portal"": [""Raptor Cloak"", ""Negatron Cloak""], ""Phage"": [""Ruby Crystal"", ""Long Sword""], ""Wicked Hatchet"": [""Brawler's Gloves"", ""Long Sword""], ""Sterak's Gage"": [""Jaurim's Fist"", ""Pickaxe"", ""Ruby Crystal""], ""Enchantment: Runic Echoes"": [""Aether Wisp"", ""Amplifying Tome""], ""Zeke's Convergence"": [""Aegis of the Legion"", ""Glacial Shroud""], ""Abyssal Mask"": [""Catalyst of Aeons"", ""Negatron Cloak""], ""Wooglet's Witchcap"": [""Seeker's Armguard"", ""Needlessly Large Rod"", ""Stopwatch""], ""Moonflair Spellblade"": [""Seeker's Armguard"", ""Negatron Cloak""]}
        ";


        dynamic stuffn = JsonConvert.DeserializeObject(item_json);
        foreach (Newtonsoft.Json.Linq.JProperty b in stuffn) // or foreach(book b in books.Values)
        {
            //Debug.Log((List<String>) b.Value == items);
            bool success = true;
            int length = 0;
            foreach (String s in b.Value)
            {
                if (success)
                {
                    //int cindex = s.IndexOf("(Clone)");
                    //String sc = s;
                    //if (cindex != -1)
                    //{
                    //    sc = s.Substring(0, cindex);
                    //}
                    bool successinner = false;
                    Debug.Log("actual items");
                    foreach(String citem in items)
                    {
                        Debug.Log(citem);
                        Debug.Log(s);
                        if (s.StartsWith(citem))
                        {
                            Debug.Log("ITS IN");
                            successinner = true;
                        }
                    }
                    if (!successinner)
                    {
                        success = false;
                    }
                    //if (!items.Contains(sc))
                    //{
                    //    success = false;
                    //}
                }
                length++;
            }
            if (items.Count != length)
            {
                success = false;
            }
            if (success)
            {
                return (b.Name);
            }
        };
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("beforeIf: " + other.name);
        if (!other.name.Equals("[VRTK][AUTOGEN][Controller][CollidersContainer]") && !other.name.Equals("DestinationPoint"))
        {
            Debug.Log("Collided: " + other.name);
            tableObjects.Add(other.gameObject);
            Debug.Log("Items in table");
            foreach(GameObject sitem in tableObjects)
            {
                Debug.Log(sitem.name);
            }
            Debug.Log("end");
            if (findHigherLevelItem(getNames(tableObjects)) != null)
            {
                CombineItem(tableObjects, other.name);
            }
        }
    }
    List<String> getNames(List<GameObject> lg)
    {
        List<String> gNames = new List<String>();
        foreach (GameObject g in lg)
        {
            gNames.Add(g.name);
        }
        return gNames;
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.name.Equals("[VRTK][AUTOGEN][Controller][CollidersContainer]") && !other.name.Equals("DestinationPoint"))
        {
            Debug.Log("Collided: " + other.name);
            tableObjects.Remove(other.gameObject);
            if (findHigherLevelItem(getNames(tableObjects)) != null)
            {
                CombineItem(tableObjects, other.name);
            }
        }
    }
    void CombineItem(List<GameObject> tableObjects, String lastObject)
    {
        Debug.Log("Last item that worked" + lastObject);
        Debug.Log("Combined to create: ");
        String newItem = findHigherLevelItem(getNames(tableObjects));
        foreach (GameObject item in tableObjects)
        {
            Destroy(item);
        }
        tableObjects = null;
        Debug.Log("Created the object");
        Debug.Log(newItem);
        Instantiate(GameObject.Find(newItem), transform.position, transform.rotation);
    }
}
public class ListEqualityComparer<T> : IEqualityComparer<List<T>>
{
    public bool Equals(List<T> list1, List<T> list2)
    {
        return list1.SequenceEqual(list2);
    }

    public int GetHashCode(List<T> list)
    {
        if (list != null && list.Count > 0)
        {
            var hashcode = list[0].GetHashCode();
            for (var i = 1; i <= list.Count; i++)
                hashcode ^= list[i].GetHashCode();

            return hashcode;
        }

        return 0;
    }
}

