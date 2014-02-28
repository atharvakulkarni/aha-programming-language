unit core;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils;

type
  PahaInteger =^TahaInteger;
  TahaInteger = Int64;

  PahaCharacter = ^TahaCharacter;
  TahaCharacter = WideChar;

  TahaObject = TInterfacedObject;

  TahaComposite = TInterfacedObject;

  TahaOpaque = TInterfacedObject;

  IahaArray = interface
    function size(out value: TahaInteger): Boolean;
    function at(const index: TahaInteger; out value): Boolean;
  end;

  { TahaFooArrayWrapper }

  TahaFooArrayWrapper = class(TInterfacedObject, IahaArray)
  private
    FSize: TahaInteger;
  protected
    function size(out value: TahaInteger): Boolean;
    function at(const index: TahaInteger; out value): Boolean;
  public
    constructor Create(const content: TahaInteger);
  end;

  TahaCharArray = UnicodeString;

  { TahaCharArrayWrapper }

  TahaCharArrayWrapper = class(TInterfacedObject, IahaArray)
  private
    FSize: TahaInteger;
    FItems: PahaCharacter;
  protected
    function size(out value: TahaInteger): Boolean;
    function at(const index: TahaInteger; out value): Boolean;
  public
    constructor Create(const content: TahaCharArray);
    destructor Destroy; override;
  end;

  TahaIntArray = array of TahaInteger;

  TahaIntArrayWrapper = class(TInterfacedObject, IahaArray)
  private
    FSize: TahaInteger;
    FItems: PahaInteger;
  protected
    function size(out value: TahaInteger): Boolean;
    function at(const index: TahaInteger; out value): Boolean;
  public
    constructor Create(const content: TahaIntArray);
  end;

  TahaOtherArray = array of IUnknown;

  TahaOherArrayWrapper = class(TInterfacedObject, IahaArray)
  private
    FArray: TahaOtherArray;
  protected
    function size(out value: TahaInteger): Boolean;
    function at(const index: TahaInteger; out value): Boolean;
  public
    constructor Create(const content: TahaOtherArray);
  end;

  TahaFooRelation = interface
    function Check: Boolean;
  end;

  TahaUnaryRelation = interface
    function Check(const param): Boolean;
  end;

  TahaBinaryRelation = interface
    function Check(const param1, param2): Boolean;
  end;

  TahaUnaryFunction = interface
    function Get(const param; out value): Boolean;
  end;

  TahaBinaryFunction = interface
    function Get(const param1, param2; out value): Boolean;
  end;

function IntPlus(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
function IntMinus(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
function IntMult(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
function IntDiv(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
function IntMod(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
function IntLess(const a, b: TahaInteger): Boolean; inline;
function IntLessEqual(const a, b: TahaInteger): Boolean; inline;
function IntEqual(const a, b: TahaInteger): Boolean; inline;
function IntNotEqual(const a, b: TahaInteger): Boolean; inline;
function IntGreaterEqual(const a, b: TahaInteger): Boolean; inline;
function IntGreater(const a, b: TahaInteger): Boolean; inline;
function CharEqual(const a, b: TahaCharacter): Boolean; inline;

implementation

{ TahaCharArrayWrapper }

function TahaCharArrayWrapper.size(out value: TahaInteger): Boolean;
begin
  value := FSize;
  Result := True;
end;

function TahaCharArrayWrapper.at(const index: TahaInteger; out value): Boolean;
begin
  Result := (index >= 0) and (index < FSize);
  if Result then
    value := FItems^[index];
end;

constructor TahaCharArrayWrapper.Create(const content: TahaCharArray);
begin
  inherited Create;
  FSize := Length(content);
  GetMem(FItems, FSize * SizeOf(TahaCharacter));
  Move(content[1], FItems^, FSize * SizeOf(TahaCharacter));
end;

destructor TahaCharArrayWrapper.Destroy;
begin
  FreeMem(FItems);
  inherited Destroy;
end;

{ TahaFooArrayWrapper }

function TahaFooArrayWrapper.size(out value: TahaInteger): Boolean;
begin
  value := FSize;
  Result := True;
end;

function TahaFooArrayWrapper.at(const index: TahaInteger; out value): Boolean;
begin
  Result := True;
end;

constructor TahaFooArrayWrapper.Create(const content: TahaInteger);
begin
  FSize := content;
end;

{$O+}
function IntPlus(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
begin
  Result := True;
  try
    c := a + b;
  except
    Result := False;
  end;
end;

function IntMinus(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
begin
  Result := True;
  try
    c := a + b;
  except
    Result := False;
  end;
end;

function IntMult(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
begin
  Result := True;
  try
    c := a + b;
  except
    Result := False;
  end;
end;

function IntDiv(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
begin
  Result := True;
  try
    c := a + b;
  except
    Result := False;
  end;
end;

function IntMod(const a, b: TahaInteger; out c: TahaInteger): Boolean; inline;
begin
  Result := True;
  try
    c := a + b;
  except
    Result := False;
  end;
end;

function IntLess(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a < b;
  except
    Result := False;
  end;
end;

function IntLessEqual(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a <= b;
  except
    Result := False;
  end;
end;

function IntEqual(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a = b;
  except
    Result := False;
  end;
end;

function IntNotEqual(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a <> b;
  except
    Result := False;
  end;
end;

function IntGreaterEqual(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a >= b;
  except
    Result := False;
  end;
end;

function IntGreater(const a, b: TahaInteger): Boolean; inline;
begin
  try
    Result := a > b;
  except
    Result := False;
  end;
end;

function CharEqual(const a, b: TahaCharacter): Boolean; inline;
begin
  try
    Result := a = b;
  except
    Result := False;
  end;
end;

end.

