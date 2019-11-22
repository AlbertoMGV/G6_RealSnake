from tastypie.resources import ModelResource
from api.models import puntuaciones
from tastypie.authorization import Authorization


class puntuacionesResource(ModelResource):
	class Meta:
		queryset = puntuaciones.objects.all()
		resource_name = 'puntuaciones'
		authorization = Authorization()
