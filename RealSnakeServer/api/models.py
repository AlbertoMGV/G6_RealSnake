from django.db import models

class puntuaciones(models.Model):
	nombre = models.CharField(max_length=50)
	puntuacion = models.IntegerField()
	fecha = models.DateTimeField(auto_now_add=True)
def __str__(self):
	return '%s %s %s' % (self.nombre, self.puntuacion, self.fecha)