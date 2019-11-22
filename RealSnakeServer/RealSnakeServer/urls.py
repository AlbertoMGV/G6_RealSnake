from django.conf.urls import url, include
from django.contrib import admin
from django.urls import path
from api.resources import puntuacionesResource

puntuaciones_resource = puntuacionesResource()


urlpatterns = [
    path('admin/', admin.site.urls),
    url(r'^api/', include(puntuaciones_resource.urls)),
]
