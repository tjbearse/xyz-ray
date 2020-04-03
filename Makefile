
#TODO: OS specific paths
UNITY=$${HOME}/Unity/Hub/Editor/2019.3.0a3/Editor/Unity

builds/webgl/index.html:
	$(UNITY) -batchmode -buildTarget webgl -quit -executeMethod Build.BuildWebGL

#TODO other builds

publish-webgl: builds/webgl/index.html
	butler push builds/webgl tjbearse/xyz-ray:webgl
