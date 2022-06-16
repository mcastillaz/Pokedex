using Pokedex.Clases;

namespace Pokedex
{
    public partial class Pokedex : Form
    {
        public Pokedex()
        {
            InitializeComponent();
            CargaInicialPoke();
        }

        private async void buttonBuscar_Click(object sender, EventArgs e)
        {
            if(textBoxBuscarPokemon.Text != String.Empty)
            {
                await Leer(textBoxBuscarPokemon.Text);
            }
            else { MessageBox.Show("Digite el pokedex", "", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
           
        }

        private void LlenarPokedex(Pokemon? _pokemon)
        {
            CargarNombrePoke(_pokemon);
            CargarImagenPoke(_pokemon);
            CargarIdPoke(_pokemon);
            CargarTipoPoke(_pokemon);
            CargarAlturaPoke(_pokemon);
            CargarPesoPoke(_pokemon);
            CargarMovimientosPoke(_pokemon);
            CargarEstadisticasPoke(_pokemon);
            CargarExperienciaPoke(_pokemon);
        }

        private async Task Leer(string _idPoke)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon/"+_idPoke);
            var pokemon = Pokemon.FromJson(response);
            LlenarPokedex(pokemon);
        }

        private void CargarImagenPoke(Pokemon? _pokemon)
        {
            pictureBox1ImgPokemon.Load(_pokemon.Sprites.Other.OfficialArtwork.frontDefault.ToString());
            pictureBox2ImgPokemon.Load(_pokemon.Sprites.BackShiny.ToString());
        }

        private void CargarNombrePoke(Pokemon? _pokemon)
        {
            labelNombrePoke.Text = _pokemon.Name.ToUpper();
        }

        private void CargarIdPoke(Pokemon? _pokemon)
        {
            labelIdPoke.Text = _pokemon.id.ToString();
        }

        private void CargarTipoPoke(Pokemon? _pokemon)
        {
            labelTipoPoke.Text = _pokemon.Types[0].Type.Name.ToUpper();
        }

        private void CargarPesoPoke(Pokemon? _pokemon)
        {
            labelPeso.Text = _pokemon.Weight.ToString();
        }

        private void CargarAlturaPoke(Pokemon? _pokemon)
        {
            labelAtura.Text = _pokemon.Height.ToString();
        }

        private void CargarExperienciaPoke(Pokemon? _pokemon)
        {
            labelExperiencia.Text = _pokemon.BaseExperience.ToString();
        }

        private void CargarMovimientosPoke(Pokemon? _pokemon)
        {
            labelMov1.Text = _pokemon.Moves[0].Move.Name.ToUpper();
            labelMov2.Text = _pokemon.Moves[1].Move.Name.ToUpper();
            labelMov3.Text = _pokemon.Moves[2].Move.Name.ToUpper();
            labelMov4.Text = _pokemon.Moves[3].Move.Name.ToUpper();
        }

        private void CargarEstadisticasPoke(Pokemon? _pokemon)
        {

            labelEstadist1.Text = _pokemon.Stats[0].Stat.Name.ToUpper();
            labelVida.Text = _pokemon.Stats[0].baseStat.ToString();
            labelEstadist2.Text = _pokemon.Stats[1].Stat.Name.ToUpper();
            labelAtaque.Text = _pokemon.Stats[1].baseStat.ToString();
            labelEstadist3.Text = _pokemon.Stats[2].Stat.Name.ToUpper();
            labelDefensa.Text = _pokemon.Stats[2].baseStat.ToString();
            labelEstadist4.Text = _pokemon.Stats[5].Stat.Name.ToUpper();
            labelVelocidad.Text = _pokemon.Stats[5].baseStat.ToString();
        }

        private void CargaInicialPoke()
        {
            int id = 30;
            int peso = 200;
            int altura = 8;
            int experiencia = 128;
            int ataque = 88;
            int vida = 35;
            int velocidad = 90;
            int defensa = 40;
            string nombre = "nidorina";
            string tipo = "poison";
            string mov1 = "scratch";
            string mov2 = "cut";
            string mov3 = "double-kick";
            string mov4 = "headbutt";
            string estadist1 = "hp";
            string estadist2 = "defense";
            string estadist3 = "speed";
            string estadist4 = "attack";
            pictureBox2ImgPokemon.Load("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/shiny/30.png");
            pictureBox1ImgPokemon.Load("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/30.png");
            labelNombrePoke.Text = nombre.ToUpper();
            labelExperiencia.Text = experiencia.ToString();
            labelTipoPoke.Text = tipo.ToUpper();
            labelIdPoke.Text = id.ToString();
            labelPeso.Text = peso.ToString();
            labelAtura.Text = altura.ToString();
            labelMov1.Text = mov1.ToUpper();
            labelMov2.Text = mov2.ToUpper();
            labelMov3.Text = mov3.ToUpper();
            labelMov4.Text = mov4.ToUpper();
            labelEstadist1.Text = estadist1.ToUpper();
            labelEstadist2.Text = estadist2.ToUpper();
            labelEstadist3.Text = estadist3.ToUpper();
            labelEstadist4.Text = estadist4.ToUpper();
            labelAtaque.Text = ataque.ToString();
            labelDefensa.Text = defensa.ToString();
            labelVelocidad.Text = velocidad.ToString();
            labelVida.Text = vida.ToString();
        }
    }
}