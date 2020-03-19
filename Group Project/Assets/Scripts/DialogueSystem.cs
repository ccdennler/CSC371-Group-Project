using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static bool talkMadame = false;
    public static bool talkSnowball = false;
    public static bool talkProfessor = false;
    public static bool talkClaw = false;
    public static bool talkChives = false;
    public static bool talkOlive = false;
    public static bool talkGhost = false;
    public static bool stage0 = false;
    public static bool stage1 = false;
    public static bool stage2 = false;
    public static bool stage3 = false;
    public static bool stage4 = false;
    public static bool stage25 = false;
    public static bool black = false;

    public static void ResetTalk()
    {
        talkMadame = false;
        talkSnowball = false;
        talkClaw = false;
        talkChives = false;
        talkOlive = false;
        talkGhost = false; 
        talkProfessor = false;
    }

    public static string GetText(string name, int stage)
    {
        if (name == "Madame")
        {
            talkMadame = true;
            if (stage == 0)
            {
                return "Thank you for coming, Detective. Feel free to explore Meow Manor and see what you can find..";
            }
            else if (stage == 1 && Clues.hasKey1)
            {
                return "My library has tons of books! Perhaps you’ll find more information on the ghosts there..";
            }
            else if (stage == 1 && Clues.hasNecklace)
            {
                Inventory.addItem("Key 1");
                Inventory.removeItem("Necklace");
                return "My necklace! thank goodness! I guess it wasn’t ghosts after all… Here! Take my library key you sweet little kitty..";
            }
            else if (stage == 1)
            {
                return "Ohhhh NOOOOOOOOOOOOOOOOOOOOOO!!!!! I am missing my sweet grandmother's beloved! Exquisite! Divine! Pearl necklace!.";
            }
            else if (stage == 2)
            {
                return "You think you need to see something in my rare collection? Pffff. I don't even remember the code. Maybe Chives knows..";
            }
            else if (stage == 3)
            {
                return "My dear Snowball? He has nothing to do with this. That pure, sweet boy is off meandering somewhere innocently. I am sure of it!.";
            }
            else if (stage == 4)
            {
                return "Ohhhhhh SNOWBALL my dear kitten, I did not know how much you were hurting. Where is my fluffykins, give momma a big hug..";
            }
        }
        if (name == "Snowball")
        {
            talkSnowball = true;
            if (stage == 0)
            {
                return "who r u? ................ do u have 4nite on ur phone..?.";
            }
            else if (stage == 1)
            {
                return "my mom is so dramatic lol. everything is fine… I think..";
            }
            else if (stage == 2 && Clues.hasLetterDad)
            {
                stage2 = true;
                return "my letter to dad… but how’d you get that? uh - i mean that’s not mine! leave me alone!";
            }
            else if (stage == 2 && !Clues.hasLetterDad)
            {
                return "the collection room key is soooo easy to find. guess u r just dumb lol..";
            }
            else if (stage == 3)
            {
                Inventory.addItem("Key 3");
                stage3 = true;
                return "i got scared and left a haunted vase in the attic through the lab.. will u help me get it plz? b4 my mom finds out..";
            }
            else if (stage == 4)
            {
                return "dad... i am so glad i got to see him one last time. thank u for everything paws. guess u aren't dumb after all..";
            }
        }
        if (name == "Professor")
        {
            talkProfessor = true;
            if (stage == 0)
            {
                return "Ah, hello! My name is Professor Purrl....Don’t tell anyone, but I'm excited to see ghosts. It’s purrfect research material!.";
            }
            else if (stage == 1 && Clues.hasBook)
            {
                Clues.hasBook = false;
                return "Sorry, my notes are a mess- I’ve been so busy reading about ghosts! I think I’m getting close.. Talk to me in a second..";
            }
            else if (stage == 1 && !Clues.hasBook)
            {
                stage1 = true;
                return " You know… Madame’s husband was an art collector. Perhaps the ghosts have to do with something in his collection room..";
            }
            else if (stage == 2)
            {
                return "I know there is a collection somewhere in this manor, but I cannot get into it. Ask around and find a way in..";
            }
            else if (stage == 3)
            {
                return "That is definitely a certain cat's game. Unfortunately, I do not have any idea where a toy would be..";
            }
            else if (stage == 4)
            {
                return "How fascinating. The boy wanted to get back his father and unlocked a power that I knew barely anything about. Surely a fascinating night, Paws..";
            }
        }
        if (name == "Claw" || name == "Scratch")
        {
            talkClaw = true;
            if (stage == 0)
            {
                return "New kitty! We’re Scratch and Claw. Wanna play with us?.";
            }
            else if (stage == 1)
            {
                return "Some of the ghosts like playing with us, so why won't you?.";
            }
            else if (stage == 2)
            {
                return "Daddy's treasure collection? We are not allowed to go in there mister..";
            }
            else if (stage == 3 && !Clues.hasDoll)
            {
                return "You have our doll. Snowball told us so. Play with us mister and then we will move..";
            }
            else if (stage == 3 && Clues.hasDoll)
            {
                Inventory.removeItem("Doll");
                stage25 = true;
                return "Give me that! Mine!";
            }
            else if (stage == 4)
            {
                return "We miss our daddy but we were really young when he passed away..";
            }
        }
        if (name == "Chives")
        {
            talkChives = true;
            if (stage == 0 && Clues.hasCake)
            {
                return "Olive in the garden loves cake. Would you be so kind to take it to her for me?.";
            }
            else if (stage == 0 && (Clues.hasEgg || Clues.hasCakeMix || Clues.hasButter))
            {
                return "No, no, no! I can’t make a cake without cake mix, eggs, and butter. The oven should also be preheated..";
            }
            else if (stage == 0)
            {
                return "Welcome to the manor Detective Paws. I was just baking a cake but I think ghosts scattered the ingredients. Will you be so kind and help me?.";
            }
            else if (stage == 1)
            {
                return "Thank you for the cake ingredients, this helps me out significantly. Go see if Madame Chatte needs any more help.";
            }
            else if (stage == 2)
            {
                return "Misseur, even I do not know the code to the collection. No one has touched it ever since.. oh nevermind. Ignore me..";
            }
            else if (stage == 3)
            {
                return "A doll? I do believe I have seen one around, but those twins are always littering their toys all over the mansion..";
            }
            else if (stage == 4)
            {
                return "Ahhhh we all felt devastated by the passing of my old boss. I am glad I could see him once more..";
            }
        }
        if (name == "Olive")
        {
            talkOlive = true;
            if (stage == 0 && Clues.hasCake == false)
            {
                return "Why is this ghost bothering me ..... I just want to plant my flowers...";
            }
            else if (stage == 0 && talkChives)
            {
                Inventory.removeItem("Cake");
                return "Oh! Cake! Can you distract this ghost please? I don't want my cake destroyed..";
            }
            else if (stage == 1)
            {
                return "Just tending to the weeds... Got nothing to say..";
            }
            else if (stage == 2)
            {
                return "I don’t know where the collection room key in the living room is… I only care for my plants..";
            }
            else if (stage == 3)
            {
                return "The twins sometimes play outside, maybe they lost it out here..";
            }
            else if (stage == 4)
            {
                return "The heart needs to be tended to, just like the plants in my garden..";
            }
        }
        if (name == "Ghost")
        {
            talkGhost = true;
            if (stage == 0 && talkOlive && Clues.hasCake)
            {
                stage0 = true;
                return "oOoOo I am here, but I do not knoooow why.. The other ghooosts are agitated ooover some object or sooomething… I just want to go hooome..";
            } else if (stage == 0)
            {
                return ".....";
            }
            if (stage == 1)
            {
                return "ooOoo I wasn’t stealing I swear...just… looOooking..";
            }
            if (stage == 2)
            {
                return "OooOoo it’s been sooOo long since I’ve had a scrub a dub dub..";
            }
            if (stage == 3)
            {
                return "...Something is ooofffffff";
            }
            if (stage == 4)
            {
                return "My soooooooon. I loooooove yoooooou...... Gooooooodbye..";
            }
        }
        if (name == "Oven")
        {
            if (!(Clues.hasEgg && Clues.hasCakeMix && Clues.hasButter) && (Clues.hasEgg || Clues.hasCakeMix || Clues.hasButter))
            {
                return "I can't make a cake without all the ingredients..";
            }
            else if (Clues.hasEgg && Clues.hasButter && Clues.hasCakeMix)
            {
                Clues.hasEgg = false;
                Clues.hasButter = false;
                Clues.hasCakeMix = false;
                Clues.hasCake = true;
                Inventory.removeItem("Cake Mix");
                Inventory.removeItem("Butter");
                Inventory.removeItem("Egg");
                Inventory.addItem("Cake");
                return "Time to bake this cake!.";
            }
            if (stage == 0)
            {
                return "Looks like the oven's preheated....";
            } else
            {
                return "The oven smells like cake...";
            }
        }
        if (name == "Cake")
        {
            return "mmmmm, num nums. Must be Chives' special recipe..";
        }
        if (name == "Photograph")
        {
            return "Oh. Its a photograph of Madame Chat at her husbands funeral… she looks so sad..";
        }
        if (name == "Madame Letter")
        {
            return "Hmm. A love letter from Mr. Chatte to Madame..";
        }
        if (name == "Secret Bookcase")
        {
            if (Clues.hasBook)
            {
                Inventory.removeItem("Book");
                return "Looks like it opened a secret passage?.";
            }
            return "Looks like a book is missing... Someone who hoards books must have taken it..";
        }
        if (name.Contains("Bookcase"))
        {
            return "Nothing suspicious here. Who even reads anymore?.";
        }
        if (name == "Notes") 
        {
            return "Looks like Professor Purrl was doodling little ghosts in the margins of her notes..";
        }
        if (name == "Computer")
        {
            return "A webpage ghostfacts.com is up. It says that disturbing ancient relics can conjure spirits. Ouija boards, sarcophagus’s, ancient pottery... ";
        }
        if (name == "Ghost Book")
        {
            return "Says here handwritten letters can be used to talk to the dead..";
        }
        if (name == "Painting")
        {
            return "What a strange painting..";
        }
        if (name == "Madame Painting")
        {
            return "Oh.. it's a painting of Madame Chatte at her husband's funeral.. she looks so sad..";
        }
        if (name == "Fossil 1")
        {
            return "I don’t think the ghosts are Dino-Aged..";
        }
        if (name == "Fossil 2")
        {
            return "This fossil is from 30 years ago! Incredible!.";
        }
        if (name == "Missing Crate")
        {
            if (Clues.hasCrowbar)
            {
                Inventory.removeItem("Crowbar");
                return "Whatever used to be in here sure isn’t anymore!.";
            } else
            {
                return "It looks like this crate has been tampered with… maybe there’s a way to open it..";
            }
        }
        if (name == "Switch")
        {
            return "No way! This kid got access to New Horizons early… must resist!.";
        }
        if (name == "Pizza")
        {
            return "!!!!!";
        }
        if (name == "Library Door")
        {
            if (Clues.hasKey1)
            {
                Inventory.removeItem("Key 1");
                return "Unlocked!.";
            } else
            {
                return "Library is locked..";
            }
        }
        if (name == "Collection Door")
        {
            if (Clues.hasKey2)
            {
                Inventory.removeItem("Key 2");
                return "Unlocked!.";
            }
            else
            {
                return "Collection is locked..";
            }
        }
        if (name == "Papers")
        {
            return "Why were these papers just carelessly tossed on the floor....";
        }

        if (name == "Dirt")
        {
            return "Just a bunch of dirt. Looks fun to play in..";
        }
        if (name == "Piano")
        {
            return "This piano is so out of tune....";
        }
        return "";
    }
}
