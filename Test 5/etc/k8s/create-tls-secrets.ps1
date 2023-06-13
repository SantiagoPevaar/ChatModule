mkcert `
"test5-st-authserver" `
"test5-st-angular" `
"test5-st-public-web" `
"test5-st-gateway-web" "test5-st-gateway-web-public" `
"test5-st-identity" "test5-st-administration" "test5-st-saas" "test5-st-product" 
kubectl create namespace test5
kubectl create secret tls -n test5 test5-tls --cert=./test5-st-authserver+8.pem  --key=./test5-st-authserver+8-key.pem