using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Monogame_1___5_Summative_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator = new Random();

        Rectangle window, fenceForeRect, fenceBackRect, fieldRect, frodoRect, samRect, pipRect, 
            tempCarrotRect, heartRect, startButtonRect, backButtonRect, cursorRect, quitButtonRect,
            titleRect, tempBabbitRect, heartScoreRect, frodoScoreRect, samScoreRect, pipScoreRect,
            infoButtonRect, infoScreenBackButtonRect;

        Texture2D fenceForeTexture, fenceBackTexture, fieldTexture, frodoTexture, samTexture, pipTexture, 
            carrotTexture, heartTexture, startButtonTexture, backButtonTexture, cursorTexture, quitButtonTexture,
            titleTexture, tempBabbitTexture, frodoScoreTexture, samScoreTexture, pipScoreTexture, thanksTexture,
            infoButtonTexture, filterTexture, infoBoxTexture, maleTexture, femaleTexture, frodoNameTexture, samNameTexture, 
            pipNameTexture, frodoInfoTexture, samInfoTexture, pipInfoTexture;

        Vector2 frodoSpeed, frodoFontVector2, samSpeed, samFontVector2, pipSpeed, pipFontVector2, frodoScoreVector2,
            samScoreVector2, pipScoreVector2;

        float seconds, delay, frodoHeart, samHeart, pipHeart, startButtonBounce, elapsedTimeSeconds, elapsedTimeMinutes;

        SpriteEffects frodoEffect, samEffect, pipEffect;

        int frodo, sam, pip, tempBabbit, frodoScore, samScore, pipScore;

        SpriteFont frodoFont, samFont, pipFont, scoreFont;

        MouseState mouseState;

        enum Screen
        {
            Intro,
            Babbits,
            Pause,
            EndScreen
        }

        Screen screen;

        Color startButtonColor, backButtonColor, quitButtonColor, infoButtonColor;

        string timerString;

        SoundEffect click, carrotSound;

        SoundEffectInstance mainScreenMusic, gameMusic, endScreenMusic;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            this.Window.Title = "Babbits";

            window = new Rectangle(0, 0, 800, 800);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            fenceBackRect = new Rectangle(50, 50, 700, 700);
            fenceForeRect = new Rectangle(50, 50, 700, 700);
            fieldRect = new Rectangle(0, 0, 800, 800);

            frodoRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 150, 150);
            frodoSpeed = new Vector2(2, 2);
            frodo = 1;

            samRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 150, 150);
            samSpeed = new Vector2(2, 2);
            sam = 1;

            pipRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 175, 175);
            pipSpeed = new Vector2(2, 2);
            pip = 1;

            tempCarrotRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 75, 75);            

            seconds = 0;

            screen = Screen.Intro;

            startButtonRect = new Rectangle(240, 350, 300, 100);
            backButtonRect = new Rectangle(10, 10, 150, 50);
            quitButtonRect = new Rectangle(675, 740, 115, 50);

            startButtonColor = Color.White;
            backButtonColor = Color.White;
            quitButtonColor = Color.White;

            cursorRect = new Rectangle(0, 0, 37, 50);

            titleRect = new Rectangle(25, -25, 750, 400);
            tempBabbitRect = new Rectangle(-600, 500, 300, 300);
            tempBabbit = generator.Next(1, 4);

            frodoScore = 0;
            samScore = 0;
            pipScore = 0;
            heartScoreRect = new Rectangle(720, 125, 65, 65);
            frodoScoreRect = new Rectangle(710, 250, 90, 90);
            samScoreRect = new Rectangle(710, 400, 90, 90);
            pipScoreRect = new Rectangle(710, 550, 90, 90);

            infoButtonRect = new Rectangle(675, 10, 113, 50);
            infoScreenBackButtonRect = new Rectangle(325, 700, 150, 50);

            frodoScoreVector2 = new Vector2(750, 325);
            samScoreVector2 = new Vector2(750, 475);
            pipScoreVector2 = new Vector2(750, 625);


        base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            fenceBackTexture = Content.Load<Texture2D>("FenceBackground");
            fenceForeTexture = Content.Load<Texture2D>("FenceForeground");
            fieldTexture = Content.Load<Texture2D>("Field V2");

            frodoTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
            frodoFont = Content.Load<SpriteFont>("FrodoFont");

            samTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
            samFont = Content.Load<SpriteFont>("FrodoFont");

            pipTexture = Content.Load<Texture2D>("PippinBunny-1.png");
            pipFont = Content.Load<SpriteFont>("FrodoFont");

            carrotTexture = Content.Load<Texture2D>("Carrot");
            heartTexture = Content.Load<Texture2D>("heart V3");

            startButtonTexture = Content.Load<Texture2D>("StartButton");
            backButtonTexture = Content.Load<Texture2D>("BackButton");
            quitButtonTexture = Content.Load<Texture2D>("QuitButton");

            cursorTexture = Content.Load<Texture2D>("HandCursorOpen");

            titleTexture = Content.Load<Texture2D>("TheBabbits");

            frodoScoreTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
            samScoreTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
            pipScoreTexture = Content.Load<Texture2D>("PippinBunny-1.png");
            scoreFont = Content.Load<SpriteFont>("ScoreFont");

            tempBabbitTexture = Content.Load<Texture2D>("PippinBunny-1.png");

            thanksTexture = Content.Load<Texture2D>("ThanksForPlaying");

            infoButtonTexture = Content.Load<Texture2D>("InfoButton");
            filterTexture = Content.Load<Texture2D>("BlackFilter");

            infoBoxTexture = Content.Load<Texture2D>("InfoBox");
            maleTexture = Content.Load<Texture2D>("Male");
            femaleTexture = Content.Load<Texture2D>("Female");
            frodoNameTexture = Content.Load<Texture2D>("Frodo2");
            samNameTexture = Content.Load<Texture2D>("Samwise");
            pipNameTexture = Content.Load<Texture2D>("Pippin");

            frodoInfoTexture = Content.Load<Texture2D>("FrodoReal");
            samInfoTexture = Content.Load<Texture2D>("SamReal");
            pipInfoTexture = Content.Load<Texture2D>("PippinReal");

            click = Content.Load<SoundEffect>("Click");
            carrotSound = Content.Load<SoundEffect>("LevelUp");

            mainScreenMusic = Content.Load<SoundEffect>("IntroMusic").CreateInstance();
            gameMusic = Content.Load<SoundEffect>("GameMusic").CreateInstance();
            endScreenMusic = Content.Load<SoundEffect>("EndMusic").CreateInstance();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            mouseState = Mouse.GetState();

            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

            cursorRect.X = (mouseState.X - 18);
            cursorRect.Y = (mouseState.Y - 25);          

            if (screen == Screen.Intro)
            {
                if (startButtonRect.Contains(mouseState.Position))
                {
                    startButtonColor = Color.Green;
                    cursorTexture = Content.Load<Texture2D>("HandCursorClick");
                }
                else
                {
                    startButtonColor = Color.White;
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (startButtonRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    click.Play();
                    screen = Screen.Babbits;
                }

                startButtonBounce += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (startButtonBounce >= 10 && startButtonBounce <= 10.2)
                {
                    startButtonRect.Y -= 1;
                }
                else if (startButtonBounce > 10.2 && startButtonBounce <= 10.4)
                {
                    startButtonRect.Y += 1;
                }
                else if (startButtonBounce >= 10.4 && startButtonBounce <= 10.6)
                {
                    startButtonRect.Y -= 1;
                }
                else if (startButtonBounce > 10.6 && startButtonBounce <= 10.8)
                {
                    startButtonRect.Y += 1;
                }
                else if (startButtonBounce > 11)
                {
                    startButtonBounce = 0f;
                }

                if (tempBabbit == 1)
                {
                    frodo++;

                    if (frodo == 1)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
                    }
                    else if (frodo == 10)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("FrodoBunny-2.png");
                    }
                    else if (frodo == 20)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("FrodoBunny-3.png");
                    }
                    else if (frodo == 30)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("FrodoBunny-4.png");
                        frodo = 1;
                    }
                }
                else if (tempBabbit == 2)
                {
                    sam++;

                    if (sam == 1)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
                    }
                    else if (sam == 10)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("SamwiseBunny-2.png");
                    }
                    else if (sam == 20)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("SamwiseBunny-3.png");
                    }
                    else if (sam == 30)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("SamwiseBunny-4.png");
                        sam = 1;
                    }
                }
                else if (tempBabbit == 3)
                {
                    pip++;

                    if (pip == 1)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("PippinBunny-1.png");
                    }
                    else if (pip == 10)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("PippinBunny-2.png");
                    }
                    else if (pip == 20)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("PippinBunny-3.png");
                    }
                    else if (pip == 30)
                    {
                        tempBabbitTexture = Content.Load<Texture2D>("PippinBunny-4.png");
                        pip = 1;
                    }
                }

                tempBabbitRect.X += 4;
                if (tempBabbitRect.Right > 2000)
                {
                    tempBabbitRect.X = -600;
                    tempBabbit = generator.Next(1, 4);
                }

                elapsedTimeSeconds = 0f;
                elapsedTimeMinutes = 0f;
                frodoScore = 0;
                samScore = 0;
                pipScore = 0;

                mainScreenMusic.Play();
                gameMusic.Stop();
            }

            if (screen == Screen.Babbits)
            {
                elapsedTimeSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (elapsedTimeSeconds > 59)
                {
                    elapsedTimeSeconds = 0f;
                    elapsedTimeMinutes++;
                }

                timerString = elapsedTimeMinutes.ToString("0") + ":" + elapsedTimeSeconds.ToString("00");

                if (seconds > 0)
                {
                    frodo++;

                    if (frodo == 1)
                    {
                        frodoTexture = Content.Load<Texture2D>("FrodoBunny-1.png");
                    }
                    else if (frodo == 10)
                    {
                        frodoTexture = Content.Load<Texture2D>("FrodoBunny-2.png");
                    }
                    else if (frodo == 20)
                    {
                        frodoTexture = Content.Load<Texture2D>("FrodoBunny-3.png");
                    }
                    else if (frodo == 30)
                    {
                        frodoTexture = Content.Load<Texture2D>("FrodoBunny-4.png");
                        frodo = 1;
                    }

                    sam++;

                    if (sam == 1)
                    {
                        samTexture = Content.Load<Texture2D>("SamwiseBunny-1.png");
                    }
                    else if (sam == 10)
                    {
                        samTexture = Content.Load<Texture2D>("SamwiseBunny-2.png");
                    }
                    else if (sam == 20)
                    {
                        samTexture = Content.Load<Texture2D>("SamwiseBunny-3.png");
                    }
                    else if (sam == 30)
                    {
                        samTexture = Content.Load<Texture2D>("SamwiseBunny-4.png");
                        sam = 1;
                    }

                    pip++;

                    if (pip == 1)
                    {
                        pipTexture = Content.Load<Texture2D>("PippinBunny-1.png");
                    }
                    else if (pip == 10)
                    {
                        pipTexture = Content.Load<Texture2D>("PippinBunny-2.png");
                    }
                    else if (pip == 20)
                    {
                        pipTexture = Content.Load<Texture2D>("PippinBunny-3.png");
                    }
                    else if (pip == 30)
                    {
                        pipTexture = Content.Load<Texture2D>("PippinBunny-4.png");
                        pip = 1;
                    }
                }

                frodoRect.X += (int)frodoSpeed.X;
                frodoRect.Y += (int)frodoSpeed.Y;

                if (frodoSpeed.X > 0)
                {
                    frodoEffect = SpriteEffects.FlipHorizontally;
                }
                else if (frodoSpeed.X < 0)
                {
                    frodoEffect = SpriteEffects.None;
                }

                if (frodoRect.Right > 735 || frodoRect.Left < 75)
                {
                    frodoSpeed.X *= -1;

                    if (frodoSpeed.Y < 0)
                    {
                        frodoSpeed.Y = (generator.Next(-5, 1));
                    }
                    else
                    {
                        frodoSpeed.Y = (generator.Next(0, 6));
                    }
                }

                if (frodoRect.Bottom > 750 || frodoRect.Top < 100)
                {
                    frodoSpeed.Y *= -1;

                    if (frodoSpeed.X < 0)
                    {
                        frodoSpeed.X = (generator.Next(-5, 1));
                    }
                    else
                    {
                        frodoSpeed.X = (generator.Next(0, 6));
                    }
                }

                if (frodoRect.Contains(mouseState.Position))
                {
                    frodoFontVector2 = new Vector2((frodoRect.X) + 50, (frodoRect.Y) + 115);
                }
                else
                {
                    frodoFontVector2 = new Vector2(-100, -100);
                }

                if (frodoRect.X <= 0 || frodoRect.Left >= 800 || frodoRect.Y <= 0 || frodoRect.Bottom >= 800)
                {
                    frodoRect.X = 350;
                    frodoRect.Y = 350;
                }

                if (frodoRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorGrab");
                    frodoRect.X = (mouseState.X - 65);
                    frodoRect.Y = (mouseState.Y - 65);

                    if (mouseState.X < 75 || mouseState.X > 700 || mouseState.Y < 150 || mouseState.Y > 625)
                    {
                        frodoRect.X = 350;
                        frodoRect.Y = 350;
                    }
                }
                else if (!pipRect.Contains(mouseState.Position) && !samRect.Contains(mouseState.Position) && !frodoRect.Contains(mouseState.Position)
                    || mouseState.LeftButton == ButtonState.Released)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                samRect.X += (int)samSpeed.X;
                samRect.Y += (int)samSpeed.Y;

                if (samSpeed.X > 0)
                {
                    samEffect = SpriteEffects.FlipHorizontally;
                }
                else if (samSpeed.X < 0)
                {
                    samEffect = SpriteEffects.None;
                }

                if (samRect.Right > 735 || samRect.Left < 75)
                {
                    samSpeed.X *= -1;

                    if (samSpeed.Y < 0)
                    {
                        samSpeed.Y = (generator.Next(-5, 1));
                    }
                    else
                    {
                        samSpeed.Y = (generator.Next(0, 6));
                    }
                }

                if (samRect.Bottom > 750 || samRect.Top < 100)
                {
                    samSpeed.Y *= -1;

                    if (samSpeed.X < 0)
                    {
                        samSpeed.X = (generator.Next(-5, 1));
                    }
                    else
                    {
                        samSpeed.X = (generator.Next(0, 6));
                    }
                }

                if (samRect.Contains(mouseState.Position))
                {
                    samFontVector2 = new Vector2((samRect.X) + 40, (samRect.Y) + 115);
                }
                else
                {
                    samFontVector2 = new Vector2(-100, -100);
                }

                if (samRect.X <= 0 || samRect.Left >= 800 || samRect.Y <= 0 || samRect.Bottom >= 800)
                {
                    samRect.X = 350;
                    samRect.Y = 350;
                }

                if (samRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorGrab");
                    samRect.X = (mouseState.X - 65);
                    samRect.Y = (mouseState.Y - 65);

                    if (mouseState.X < 75 || mouseState.X > 735 || mouseState.Y < 150 || mouseState.Y > 650)
                    {
                        samRect.X = 350;
                        samRect.Y = 350;
                    }
                }
                else if (!pipRect.Contains(mouseState.Position) && !samRect.Contains(mouseState.Position) && !frodoRect.Contains(mouseState.Position)
                    || mouseState.LeftButton == ButtonState.Released)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                pipRect.X += (int)pipSpeed.X;
                pipRect.Y += (int)pipSpeed.Y;

                if (pipSpeed.X > 0)
                {
                    pipEffect = SpriteEffects.FlipHorizontally;
                }
                else if (pipSpeed.X < 0)
                {
                    pipEffect = SpriteEffects.None;
                }

                if (pipRect.Right > 735 || pipRect.Left < 75)
                {
                    pipSpeed.X *= -1;

                    if (pipSpeed.Y < 0)
                    {
                        pipSpeed.Y = (generator.Next(-5, 1));
                    }
                    else
                    {
                        pipSpeed.Y = (generator.Next(0, 6));
                    }
                }

                if (pipRect.Bottom > 750 || pipRect.Top < 100)
                {
                    pipSpeed.Y *= -1;

                    if (pipSpeed.X < 0)
                    {
                        pipSpeed.X = (generator.Next(-5, 1));
                    }
                    else
                    {
                        pipSpeed.X = (generator.Next(0, 6));
                    }
                }

                if (pipRect.Contains(mouseState.Position))
                {
                    pipFontVector2 = new Vector2((pipRect.X) + 70, (pipRect.Y) + 130);
                }
                else
                {
                    pipFontVector2 = new Vector2(-100, -100);
                }

                if (pipRect.X <= 0 || pipRect.Left >= 800 || pipRect.Y <= 0 || pipRect.Bottom >= 800)
                {
                    pipRect.X = 350;
                    pipRect.Y = 350;
                }

                if (pipRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorGrab");
                    pipRect.X = (mouseState.X - 75);
                    pipRect.Y = (mouseState.Y - 75);

                    if (mouseState.X < 75 || mouseState.X > 735 || mouseState.Y < 150 || mouseState.Y > 650)
                    {
                        pipRect.X = 350;
                        pipRect.Y = 350;
                    }
                }
                else if (!pipRect.Contains(mouseState.Position) && !samRect.Contains(mouseState.Position) && !frodoRect.Contains(mouseState.Position)
                    || mouseState.LeftButton == ButtonState.Released)
                {
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (frodoRect.Contains(tempCarrotRect))
                {
                    tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                    frodoHeart = 300;

                    frodoScore++;

                    carrotSound.Play();
                }
                if (samRect.Contains(tempCarrotRect))
                {
                    tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                    samHeart = 300;

                    samScore++;

                    carrotSound.Play();
                }
                if (pipRect.Contains(tempCarrotRect))
                {
                    tempCarrotRect = new Rectangle(-100, -100, 75, 75);
                    pipHeart = 300;

                    pipScore++;

                    carrotSound.Play();
                }

                if (tempCarrotRect.X == -100)
                {
                    delay = generator.Next(150, 1500);
                    tempCarrotRect = new Rectangle(-101, -100, 75, 75);
                }
                if (tempCarrotRect.X == -101)
                {
                    delay--;

                    if (delay < 0)
                    {
                        tempCarrotRect = new Rectangle(generator.Next(100, 600), generator.Next(100, 600), 75, 75);
                    }
                }

                if (frodoHeart > 0)
                {
                    frodoHeart--;

                    if (frodoEffect == SpriteEffects.None)
                    {
                        heartRect = new Rectangle((frodoRect.X + 20), (frodoRect.Y - 30), 50, 50);
                    }
                    else
                    {
                        heartRect = new Rectangle((frodoRect.X + 70), (frodoRect.Y - 30), 50, 50);
                    }
                }
                if (samHeart > 0)
                {
                    samHeart--;

                    if (samEffect == SpriteEffects.None)
                    {
                        heartRect = new Rectangle((samRect.X + 20), (samRect.Y - 30), 50, 50);
                    }
                    else
                    {
                        heartRect = new Rectangle((samRect.X + 70), (samRect.Y - 30), 50, 50);
                    }
                }
                if (pipHeart > 0)
                {
                    pipHeart--;

                    if (pipEffect == SpriteEffects.None)
                    {
                        heartRect = new Rectangle((pipRect.X + 30), (pipRect.Y - 30), 50, 50);
                    }
                    else
                    {
                        heartRect = new Rectangle((pipRect.X + 85), (pipRect.Y - 30), 50, 50);
                    }
                }

                if (frodoHeart <= 0 && samHeart <= 0 && pipHeart <= 0)
                {
                    heartRect = new Rectangle(-100, -100, 50, 50);
                }

                if (backButtonRect.Contains(mouseState.Position))
                {
                    backButtonColor = Color.Green;
                    cursorTexture = Content.Load<Texture2D>("HandCursorClick");
                }
                else
                {
                    backButtonColor = Color.White;
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (backButtonRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    click.Play();
                    screen = Screen.Intro;
                }

                if (quitButtonRect.Contains(mouseState.Position))
                {
                    quitButtonColor = Color.Green;
                    cursorTexture = Content.Load<Texture2D>("HandCursorClick");
                }
                else
                {
                    quitButtonColor = Color.White;
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (quitButtonRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    click.Play();
                    screen = Screen.EndScreen;
                }

                if (infoButtonRect.Contains(mouseState.Position))
                {
                    infoButtonColor = Color.Green;
                    cursorTexture = Content.Load<Texture2D>("HandCursorClick");
                }
                else
                {
                    infoButtonColor = Color.White;
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (infoButtonRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    click.Play();
                    screen = Screen.Pause;
                }

                mainScreenMusic.Stop();
                gameMusic.Play();
            }

            if (screen == Screen.EndScreen)
            {
                titleRect = new Rectangle(25, 10, 750, 400);

                tempBabbitTexture = Content.Load<Texture2D>("BunnyGroup");

                endScreenMusic.Play();
                gameMusic.Stop();
            }

            if (screen == Screen.Pause)
            {
                if (infoScreenBackButtonRect.Contains(mouseState.Position))
                {
                    backButtonColor = Color.Green;
                    cursorTexture = Content.Load<Texture2D>("HandCursorClick");
                }
                else
                {
                    backButtonColor = Color.White;
                    cursorTexture = Content.Load<Texture2D>("HandCursorOpen");
                }

                if (infoScreenBackButtonRect.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed)
                {
                    click.Play();
                    screen = Screen.Babbits;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(fieldTexture, fieldRect, Color.White);

            if (screen == Screen.Intro)
            {               
                _spriteBatch.Draw(tempBabbitTexture, tempBabbitRect, null, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);

                _spriteBatch.Draw(startButtonTexture, startButtonRect, startButtonColor);

                _spriteBatch.Draw(titleTexture, titleRect, Color.White);
            }

            if (screen == Screen.Babbits)
            {
                _spriteBatch.Draw(fenceBackTexture, fenceBackRect, Color.White);

                _spriteBatch.Draw(heartTexture, heartScoreRect, Color.White);
                _spriteBatch.Draw(frodoScoreTexture, frodoScoreRect, Color.White);
                _spriteBatch.Draw(samScoreTexture, samScoreRect, Color.White);
                _spriteBatch.Draw(pipScoreTexture, pipScoreRect, Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(frodoScore), frodoScoreVector2, Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(samScore), samScoreVector2, Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(pipScore), pipScoreVector2, Color.White);

                _spriteBatch.Draw(carrotTexture, tempCarrotRect, Color.White);

                _spriteBatch.Draw(frodoTexture, frodoRect, null, Color.White, 0f, Vector2.Zero, frodoEffect, 0f);
                _spriteBatch.Draw(samTexture, samRect, null, Color.White, 0f, Vector2.Zero, samEffect, 0f);
                _spriteBatch.Draw(pipTexture, pipRect, null, Color.White, 0f, Vector2.Zero, pipEffect, 0f);

                _spriteBatch.Draw(fenceForeTexture, fenceForeRect, Color.White);

                _spriteBatch.DrawString(frodoFont, "Frodo", frodoFontVector2, Color.White);
                _spriteBatch.DrawString(samFont, "Samwise", samFontVector2, Color.White);
                _spriteBatch.DrawString(pipFont, "Pippin", pipFontVector2, Color.White);

                _spriteBatch.Draw(heartTexture, heartRect, Color.White);

                _spriteBatch.Draw(backButtonTexture, backButtonRect, backButtonColor);
                _spriteBatch.Draw(quitButtonTexture, quitButtonRect, quitButtonColor);

                _spriteBatch.DrawString(scoreFont, timerString, new Vector2(15, 765), Color.White);

                _spriteBatch.Draw(infoButtonTexture, infoButtonRect, infoButtonColor);
            }

            if (screen == Screen.EndScreen)
            {
                _spriteBatch.Draw(thanksTexture, new Rectangle (229, 35, 342, 106), Color.White);
                _spriteBatch.Draw(titleTexture, titleRect, Color.White);

                _spriteBatch.Draw(tempBabbitTexture, new Rectangle (75, 400, 650, 322), Color.White);

                _spriteBatch.DrawString(scoreFont, "Press ESC to exit...", new Vector2(315, 765), Color.White);
            }

            if (screen == Screen.Pause)
            {
                _spriteBatch.Draw(fenceBackTexture, fenceBackRect, Color.White);

                _spriteBatch.Draw(heartTexture, heartScoreRect, Color.White);
                _spriteBatch.Draw(frodoScoreTexture, frodoScoreRect, Color.White);
                _spriteBatch.Draw(samScoreTexture, samScoreRect, Color.White);
                _spriteBatch.Draw(pipScoreTexture, pipScoreRect, Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(frodoScore), new Vector2(750, 325), Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(samScore), new Vector2(750, 475), Color.White);
                _spriteBatch.DrawString(scoreFont, Convert.ToString(pipScore), new Vector2(750, 625), Color.White);

                _spriteBatch.Draw(carrotTexture, tempCarrotRect, Color.White);

                _spriteBatch.Draw(frodoTexture, frodoRect, null, Color.White, 0f, Vector2.Zero, frodoEffect, 0f);
                _spriteBatch.Draw(samTexture, samRect, null, Color.White, 0f, Vector2.Zero, samEffect, 0f);
                _spriteBatch.Draw(pipTexture, pipRect, null, Color.White, 0f, Vector2.Zero, pipEffect, 0f);

                _spriteBatch.Draw(fenceForeTexture, fenceForeRect, Color.White);

                _spriteBatch.Draw(heartTexture, heartRect, Color.White);

                _spriteBatch.Draw(backButtonTexture, backButtonRect, Color.White);
                _spriteBatch.Draw(quitButtonTexture, quitButtonRect, quitButtonColor);

                _spriteBatch.DrawString(scoreFont, timerString, new Vector2(15, 765), Color.White);

                _spriteBatch.Draw(infoButtonTexture, infoButtonRect, Color.White);

                _spriteBatch.Draw(filterTexture, new Rectangle(0, 0, 800, 800), Color.White);

                _spriteBatch.Draw(infoBoxTexture, new Rectangle(150, 75, 500, 173), Color.White);
                _spriteBatch.Draw(infoBoxTexture, new Rectangle(150, 275, 500, 173), Color.White);
                _spriteBatch.Draw(infoBoxTexture, new Rectangle(150, 475, 500, 173), Color.White);
                

                _spriteBatch.Draw(frodoInfoTexture, new Rectangle(185, 96, 162, 130), Color.White);
                _spriteBatch.Draw(frodoNameTexture, new Rectangle(360, 100, 150, 37), Color.White);
                _spriteBatch.Draw(femaleTexture, new Rectangle(525, 100, 25, 37), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("FrodoBunny-1.png"), new Rectangle(330, 135, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("FrodoBunny-2.png"), new Rectangle(400, 135, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("FrodoBunny-3.png"), new Rectangle(470, 135, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("FrodoBunny-4.png"), new Rectangle(540, 135, 110, 110), Color.White);

                _spriteBatch.Draw(samInfoTexture, new Rectangle(185, 296, 162, 130), Color.White);
                _spriteBatch.Draw(samNameTexture, new Rectangle(360, 300, 215, 37), Color.White);
                _spriteBatch.Draw(femaleTexture, new Rectangle(590, 300, 25, 37), Color.White);
                _spriteBatch.Draw(femaleTexture, new Rectangle(525, 100, 25, 37), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("SamwiseBunny-1.png"), new Rectangle(330, 335, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("SamwiseBunny-2.png"), new Rectangle(400, 335, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("SamwiseBunny-3.png"), new Rectangle(470, 335, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("SamwiseBunny-4.png"), new Rectangle(540, 335, 110, 110), Color.White);

                _spriteBatch.Draw(pipInfoTexture, new Rectangle(185, 496, 162, 130), Color.White);
                _spriteBatch.Draw(pipNameTexture, new Rectangle(360, 500, 155, 37), Color.White);
                _spriteBatch.Draw(maleTexture, new Rectangle(530, 500, 37, 37), Color.White);
                _spriteBatch.Draw(femaleTexture, new Rectangle(525, 100, 25, 37), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("PippinBunny-1.png"), new Rectangle(330, 535, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("PippinBunny-2.png"), new Rectangle(400, 535, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("PippinBunny-3.png"), new Rectangle(470, 535, 110, 110), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("PippinBunny-4.png"), new Rectangle(540, 535, 110, 110), Color.White);

                _spriteBatch.Draw(backButtonTexture, infoScreenBackButtonRect, backButtonColor);
            }

            _spriteBatch.Draw(cursorTexture, cursorRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
