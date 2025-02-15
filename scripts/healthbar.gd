@tool
extends Node

@onready var current_skin := $NormalSkin

@export var value := 100.0:
	set(val):
		value = val
		if is_node_ready():
			current_skin.value = val

@export var corrupted_skin := false:
	set(is_corrupted):
		corrupted_skin = is_corrupted
		if is_node_ready():
			current_skin.visible = false;
			current_skin = $CorruptedSkin if is_corrupted else $NormalSkin
			current_skin.value = value
			current_skin.visible = true;

func _on_health_changed(val):
	value = val
