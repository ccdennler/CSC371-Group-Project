using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static string GetText(string name, int stage)
    {
        if (name == "Madame")
        {
            if (stage == 0)
            {
                return "Thank you for coming, Detective. Feel free to explore Meow Manor and see what you can find..";
            }
            if (stage == 1)
            {
                return "Ohhhh NOOOOOOOOOOOOOOOOOOOOOO!!!!! I am missing my sweet grandmother's beloved! Exquisite! Divine! pearl necklace..";
            }
            if (stage == 2)
            {
                return "You think you need to see something in my rare collection? Pffff. I don't even remember the code. Maybe Chives knows..";
            }
            if (stage == 3)
            {
                return "My dear Snowball? He has nothing to do with this. That pure, sweet boy is off meandering somewhere innocently. I am sure of it!.";
            }
            if (stage == 4)
            {
                return "Ohhhhhh SNOWBALL my dear kitten, I did not know how much you were hurting. Where is my fluffykins, give momma a big hug..";
            }
        }
        if (name == "Snowball")
        {
            if (stage == 0)
            {
                return "who r u? ................ do u have 4nite on ur phone..?.";
            }
            if (stage == 1)
            {
                return "my mom is so dramatic lol. everything is fine...";
            }
            if (stage == 2)
            {
                return "the combination is soooo easy to figure out. guess u r just dumb lol..";
            }
            if (stage == 3)
            {
                return "yea, it is my hair. i got scared and left the haunted vase in the attic because i didn't know what to do.. will u help me get it plz? b4 my mom finds out..";
            }
            if (stage == 4)
            {
                return "dad... i am so glad i got to see him one last time. thank u for everything paws. guess u aren't dumb after all..";
            }
        }
        if (name == "Professor")
        {
            if (stage == 0)
            {
                return "To be quite honest with you, I am absolutely excited at the idea of furthering my research..";
            }
            if (stage == 1)
            {
                return "The ghosts are agitated over something? Hmmm... find any clues about ancient relics from this house that have gone missing..";
            }
            if (stage == 2)
            {
                return "I know there is a collection somewhere in this manor, but I cannot get into it. Ask around and find a way in..";
            }
            if (stage == 3)
            {
                return "That is definitely a certain cat's hair. Unfortunately, I do not have any idea where a toy would be..";
            }
            if (stage == 4)
            {
                return "How fascinating. The boy wanted to get back his father and unlocked a power that I knew barely anything about. Surely a fascinating night, Paws..";
            }
        }
        if (name == "Claw" || name == "Scratch")
        {
            if (stage == 0)
            {
                return "New kitty! Wanna play with us?.";
            }
            if (stage == 1)
            {
                return "Some of the ghosts like playing with us, so why won't you?.";
            }
            if (stage == 2)
            {
                return "Mommy's treasure collection? We are not allowed to go in there mister..";
            }
            if (stage == 3)
            {
                return "You have our doll. Snowball told us so. Play with us mister and then we will move..";
            }
            if (stage == 4)
            {
                return "We miss our daddy but we were really young when he passed away..";
            }
        }
        if (name == "Chives")
        {
            if (stage == 0)
            {
                return "Welcome to the manor Detective Paws. I was just baking a cake but lost all of the ingredients. Will you be so kind and help me?.";
            }
            if (stage == 1)
            {
                return "The ghosts are agitated over an object? Professor Purrl is an expert on haunted relics. Find her perhaps..";
            }
            if (stage == 2)
            {
                return "Misseur, even I do not know the code to the collection. No one has touched it ever since.. oh nevermind. Ignore me..";
            }
            if (stage == 3)
            {
                return "A doll? I do believe I have seen one around, but those twins are always littering their toys all over the mansion..";
            }
            if (stage == 4)
            {
                return "Ahhhh we all felt devastated by the passing of my old boss. I am glad I could see him once more..";
            }
        }
        if (name == "Hops")
        {
            if (stage == 0)
            {
                return "Listen... I can't help you... Oh hello there, rude to interrupt!.";
            }
            if (stage == 1)
            {
                return "Just tending to the weeds. Haven't seen the Madame's necklace, sorry..";
            }
            if (stage == 2)
            {
                return "A secret code? Look around you. There's patterns everywhere, even in my plants..";
            }
            if (stage == 3)
            {
                return "The twins sometimes play outside, maybe they lost it out here..";
            }
            if (stage == 4)
            {
                return "The heart needs to be tended to, just like the plants in my garden..";
            }
        }
        if (name == "Ghost")
        {
            if (stage == 0)
            {
                return "....";
            }
            if (stage == 1)
            {
                return "oOoOo I am here, but I do not knoooooow why.. The ghooosts are agitated ooover soooomething...";
            }
            if (stage == 2)
            {
                return "A missing relic? Hooooowww intriguing..";
            }
            if (stage == 3)
            {
                return "Oooooonce a looooong time agoooooo I wanted to be an actor..";
            }
            if (stage == 4)
            {
                return "My soooooooon. I loooooove yoooooou...... Gooooooodbye..";
            }
        }
        return "";
    }
}
