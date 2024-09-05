using Godot;
using System;
using System.IO.Ports;

public partial class Arduino : Node2D
{
	SerialPort serialPort;
	RichTextLabel text;
	
	public override void _Ready(){
		text = GetNode<RichTextLabel>("RichTextLabel");
		serialPort = new SerialPort();
		serialPort.PortName = "COM3"; //Se configura el puerto
		serialPort.BaudRate = 9600; //Se configura la velocidad de transmisión
		serialPort.Open(); //Se abre el puerto serial
		GD.Print("Conectado al Arduino en COM3");
	}
	
	public override void _Process(double delta){
		if(!serialPort.IsOpen) return;
		text.Text = "Funciona el boton";
		GD.Print("si entra al process");
		
		string serialMessage = serialPort.ReadLine().Trim(); //Lee cualquier dato que este en el puerto serial
		//GD.Print("Mensaje recibido: '", serialMessage, "'");
		
		
		/*if (serialMessage == "azul"){
			text.Text = "LED AZUL ENCENDIDO!";
		} else if (serialMessage == "amarillo"){
			text.Text = "LED AMARILLO ENCENDIDO!";
		} else if (serialMessage == "rojo"){
			text.Text = "LED ROJO ENCENDIDO!";
		} else if (serialMessage == "OFF"){
			text.Text = "TODOS LOS LEDS APAGADOS!";
		}*/
	}
	
	
	public void send_Data(string data){
		if (serialPort.IsOpen){
			serialPort.WriteLine(data);
			GD.Print("Comando enviado: " + data);
		}
	}
	
	public override void _ExitTree(){
		serialPort.Close();
		GD.Print("Conexión cerrada");
	}
	
}
