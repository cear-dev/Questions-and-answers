namespace TDMPW_411_3P_PR01;

public partial class MainPage : ContentPage
{
    string[] preguntas =
    {
    "¿Quién es el autor del manga \"One Piece\"?",
    "¿Cuál es el anime más popular de la década?",
    "¿Cuál es el nombre del protagonista de \"Dragon Ball Z\"?",
    "¿Qué significa \"anime\" en japonés?",
    "¿Cuál es el estudio de animación detrás de \"My Hero Academia\"?",
    "¿Cuál es el anime basado en un videojuego de cartas de monstruos?",
    "¿Quién es el director de \"Your Name\"?",
    "¿Cuál es el anime conocido por su estilo visual único y surrealista?",
    "¿Cuál es el género principal del anime \"Attack on Titan\"?",
    "¿Cuál es el anime que sigue la historia de los hermanos Elric en su búsqueda de la piedra filosofal?"
    };

    string[] respuestas =
    {
    "Eiichiro Oda",
    "Demon Slayer: Kimetsu no Yaiba",
    "Goku",
    "Animación",
    "Studio Bones",
    "Yu-Gi-Oh!",
    "Makoto Shinkai",
    "Neon Genesis Evangelion",
    "Acción y fantasía oscura",
    "Fullmetal Alchemist"};

    Random rand = new Random();
    int puntuaje = 0;
    int indice;
    string respuestaAleatoria;
    string preguntaAleatoria;
    int numeroIntentos;
    int preguntasMostradas = 1;
    bool acertada;

    public MainPage()
	{
		InitializeComponent();
        generarIndice();
        obtenerPregunta();
        eliminarPregunta();
    }


    private async void btnVerificar_Clicked(object sender, EventArgs e)
    {
        
        obtenerRespuesta();
        validarRespuesta();
        if (numeroIntentos == 2 || acertada == true) {
            numeroIntentos = 0;
            generarIndice();
            preguntasMostradas = preguntasMostradas + 1;
            if (preguntas.Length == 0)
            {
                await DisplayAlert("Alert", "Se han terminado las preguntas", "OK");
            }
            else
            {
                obtenerPregunta();
                eliminarPregunta();
            }
        }
        
        if (preguntasMostradas > 5) {
            await DisplayAlert("Perdiste", "Se ha terminado el juego", "OK");
            Application.Current.Quit();
        }
    }

    private async void validarPuntuaje() {
        if (puntuaje == 3)
        {
            await DisplayAlert("Ganaste", "Has ganado", "OK");
            Application.Current.Quit();
        }
    }
    private async void validarRespuesta() {
        if (txtRespuesta.Text == respuestaAleatoria)
        {
            acertada = true;
            eliminarRespuesta();
            await DisplayAlert("Alert", "Respuesta correcta :)", "OK");
            sumarPuntuaje();
            validarPuntuaje();
        }
        else
        {
            acertada = false;
            numeroIntentos = numeroIntentos + 1;
            await DisplayAlert("Respuesta incorrecta :(", "Intento numero: " + numeroIntentos + " pre " + preguntasMostradas, "OK");
        }
    }
    private void generarIndice() {
        indice = rand.Next(preguntas.Length);
    }
    private void sumarPuntuaje()
    {
        puntuaje = puntuaje + 1;
        txtPuntos.Text = "Puntos: " + puntuaje;
    }

    private void obtenerPregunta() {
        preguntaAleatoria = preguntas[indice];
        txtPregunta.Text = preguntaAleatoria;
    }
    private void obtenerRespuesta()
    {
        respuestaAleatoria = respuestas[indice];
    }

    private void eliminarPregunta()
    {
        preguntas = preguntas.Where((source, index) => index != indice).ToArray();
    }

    private void eliminarRespuesta() {
        respuestas = respuestas.Where((source, index) => index != indice).ToArray();
    }
}

