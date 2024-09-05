extends Button

# Variable para almacenar el estado del LED
var led_state = "LED_OFF"

func _on_pressed() -> void:
	pass # Replace with function body.
	
	# Alternar entre LED_ON y LED_OFF
	if led_state == "LED_OFF":
		Conexion_arduino.send_Data("LED_ON")
		led_state = "LED_ON"
	else:
		Conexion_arduino.send_Data("LED_OFF")
		led_state = "LED_OFF"
	print("El estado actual del LED es: ", led_state)
	
	
