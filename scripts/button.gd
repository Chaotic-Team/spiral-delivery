extends Control

func _on_button_down():
	$Textures.modulate = Color.GRAY

func _on_button_up():
	$Textures.modulate = Color.WHITE
