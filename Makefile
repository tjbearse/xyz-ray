
builds/webgl/index.html:
	test -n "${UNITY_PATH}" # $$UNITY_PATH
	${UNITY_PATH} -batchmode -buildTarget webgl -quit -executeMethod Build.BuildWebGL

#TODO other builds

publish-webgl: builds/webgl/index.html
	butler push builds/webgl tjbearse/xyz-ray:webgl
