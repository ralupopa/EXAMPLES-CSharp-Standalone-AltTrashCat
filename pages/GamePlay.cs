using System;
using System.Linq;

namespace alttrashcat_tests_csharp.pages
{
    public class GamePlay : BasePage
    {
        public GamePlay(AltUnityDriver driver) : base(driver)
        {
        }

        public AltUnityObject PauseButton{get=> Driver.WaitForElement("Game/WholeUI/pauseButton",timeout:2);}
        public AltUnityObject Character{get => Driver.WaitForElement("PlayerPivot");}

        public bool IsDisplayed(){
            if(PauseButton!=null && Character!=null){
                return true;
            }
            return false;
        }
        public void PressPause(){
            PauseButton.Tap();
        }
        public int GetCurrentLife(){
            return Int32.Parse(Character.CallComponentMethod("CharacterInputController","get_currentLife",""));
        }
        public void AvoidObstacles(int numberOfObstacles){
            var character=Character;
            bool movedLeft=false;
            bool movedRight=false;
            for(int i=0;i<numberOfObstacles;i++){
                var allObstacles=Driver.FindElementsWhereNameContains("Obstacle");
                allObstacles.Sort((x,y)=>x.worldZ.CompareTo(y.worldZ));
                allObstacles.RemoveAll(obs=>obs.worldZ>character.worldZ);
                var obstacle=allObstacles[0];
                
                System.Console.WriteLine("Obstacle: "+ obstacle.name+", z:"+obstacle.worldZ+", x:"+obstacle.worldX);
                System.Console.WriteLine("Next: "+ allObstacles[1].name+", z:"+allObstacles[1].worldZ+", x:"+allObstacles[1].worldX);

                while(obstacle.worldZ - character.worldZ>5){
                    obstacle=Driver.FindElement("id("+obstacle.id+")");
                    character=Driver.FindElement("PlayerPivot");
                }

                if(obstacle.name.Contains("Barrier")|| obstacle.name.Contains("Rat")){
                    //Jump
                }
                else{
                    if(obstacle.worldZ==allObstacles[1].worldZ)
                    {
                        if(obstacle.worldX==character.worldX){
                            if(allObstacles[1].worldX==-1.5f){
                                //Right
                                movedRight=true;
                            }
                            else{
                                //Left
                                movedLeft=true;
                            }
                        }
                        else{
                            if(allObstacles[1].worldX==character.worldX){
                                if(obstacle.worldX==-1.5f){
                                    //Right
                                    movedRight=true;
                                }
                                else{
                                    //Left
                                    movedLeft=true;
                                }
                            }
                        }
                    }
                    else{
                        if(obstacle.worldX==character.worldX){
                            //Right
                            movedRight=true;
                        }
                    }
                }
                while(character.worldZ<obstacle.worldZ && character.worldX<99){
                    obstacle=Driver.FindElement("id("+obstacle.id+")");
                    character=Driver.FindElement("PlayerPivot");
                }
                if(movedRight){
                    //Left
                    movedRight=false;
                }
                if(movedLeft){
                    //Right
                    movedRight=false;
                }
            }
            

        }
    }
}