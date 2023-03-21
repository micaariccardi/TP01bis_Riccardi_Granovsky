using System.Collections.Generic;

const string mensajeE="Error, ingrese de nuevo: ";
Dictionary<string,double> cursos = new Dictionary<string, double>();
int opcion=0, cantEstudiantes=0;
string curso="";
double recaudoCurso;
while(opcion!=2){
    opcion=IngresarDesdeHasta(" 1- Ingrese los importes de un curso.\n 2- Ver estadísticas.\nIngrese la opción que quiere llevar a cabo: ", mensajeE, 1,2);
    switch(opcion){
        case 1:
            IngresarInfoCurso(ref curso, ref cantEstudiantes, mensajeE);
            recaudoCurso = IngresarRecaudo(cantEstudiantes,"Ingrese cuánto dinero va a incluir en el regalo: ", mensajeE);
            cursos.Add(curso,recaudoCurso);
        break;
        case 2:
            Console.WriteLine("Curso que aportó más dinero: " + MayorEnDiccionario(cursos));
            Console.WriteLine("Promedio de dinero: " + PromedioDiccionario(cursos).ToString());
            Console.WriteLine("Recaudación total: " + SumaValoresDic(cursos).ToString());
            Console.WriteLine("Cantidad de cursos que participan: " + cursos.Count);
        break;
    }
}


double SumaValoresDic(Dictionary<string,double> diccionario){
    double suma=0;
    foreach(double valor in diccionario.Values){
        suma+= valor;
    }
    return suma;
}

double PromedioDiccionario(Dictionary<string,double> diccionario){
    double suma=0;
    int cont=0;
    foreach(double valor in diccionario.Values){
        suma+=valor;
        cont++;
    }
    return suma/cont;
}

string MayorEnDiccionario(Dictionary<string,double> diccionario){
    string mayorClave="";
    double mayorValor=0;
    double valor;

    foreach(string clave in diccionario.Keys){
        valor = diccionario[clave];
        if(mayorValor<valor){
            mayorValor = valor;
            mayorClave = clave;
        }
    }
    
    return mayorClave;
}

double IngresarRecaudo(int cantEstudiantes, string mensaje, string mensajeE){
    double total=0;
    for(int i=0; i<cantEstudiantes;i++){
        total += IngresarDesde(mensaje,mensajeE,0);
    }
    return total;
}

void IngresarInfoCurso(ref string curso, ref int cantEstudiantes,string mensajeE){
    Console.Write("Ingrese el curso: ");
    curso = Console.ReadLine();
    cantEstudiantes = IngresarEnteroDesde("Ingrese la cantidad de estudiantes que va a aportar dinero: ", mensajeE,0);
}

int IngresarEnteroDesde(string mensaje, string mensajeE, int desde){
    Console.Write(mensaje);
    int ingreso = int.Parse(Console.ReadLine());
    while(ingreso<=desde){
        Console.Write(mensajeE);
        ingreso = int.Parse(Console.ReadLine());
    }
    return ingreso;
}

double IngresarDesde(string mensaje, string mensajeE, double desde){
    Console.Write(mensaje);
    double ingreso = double.Parse(Console.ReadLine());
    while(ingreso<=desde){
        Console.Write(mensajeE);
        ingreso = double.Parse(Console.ReadLine());
    }
    return ingreso;
}

int IngresarDesdeHasta(string mensaje, string mensajeE, int desde, int hasta){
    Console.Write(mensaje);
    int num=int.Parse(Console.ReadLine());
    while(num<desde || num>hasta){
        Console.Write(mensajeE);
        num=int.Parse(Console.ReadLine());
    }
    return num;
}
