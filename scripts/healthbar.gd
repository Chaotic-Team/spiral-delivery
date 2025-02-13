@tool
extends Node

@onready var current_skin := $AllySkin

@export var value := 100.0:
	set(val):
		value = val
		if is_node_ready():
			current_skin.value = val

@export var enemy_skin := false:
	set(is_enemy):
		enemy_skin = is_enemy
		if is_node_ready():
			current_skin.visible = false;
			current_skin = $EnemySkin if is_enemy else $CompanionSkin
			current_skin.value = value
			current_skin.visible = true;

func _on_health_changed(val):
	value = val
